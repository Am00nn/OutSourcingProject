
using System.Net.Mail;
using System.Net;
using System.Text;
using DocuSign.eSign.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using OutsourcingSystem.Repositories;
using OutsourcingSystem.Services;


namespace OutsourcingSystem
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Log the current environment for debugging
            Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");

            // Configure EmailSettings
            builder.Services.Configure<Configurations.EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

            // Verify EmailSettings
            var emailSettings = builder.Configuration.GetSection("EmailSettings").Get<Configurations.EmailSettings>();
            if (emailSettings == null || string.IsNullOrEmpty(emailSettings.SMTPHost) || emailSettings.Port <= 0 || string.IsNullOrEmpty(emailSettings.SenderEmail))
            {
                Console.WriteLine("Invalid EmailSettings configuration. Please check the appsettings.json or appsettings.Development.json file.");
                throw new InvalidOperationException("Invalid EmailSettings configuration.");
            }
            else
            {
                Console.WriteLine($"Loaded Email Settings: SMTPHost = {emailSettings.SMTPHost}, Port = {emailSettings.Port}, SenderEmail = {emailSettings.SenderEmail}");

                // Test SMTP connection
                try
                {
                    using var smtpClient = new SmtpClient(emailSettings.SMTPHost)
                    {
                        Port = emailSettings.Port,
                        Credentials = new NetworkCredential(emailSettings.SenderEmail, emailSettings.Password),
                        EnableSsl = true
                    };

                    smtpClient.Send(new MailMessage(emailSettings.SenderEmail, emailSettings.SenderEmail, "Test", "SMTP Test Message"));
                    Console.WriteLine("SMTP connection test passed.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"SMTP connection test failed: {ex.Message}");
                    throw;
                }
            }
            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
            builder.Services.AddTransient<EmailService>();


            builder.Services.AddControllers();

            builder.Services.AddScoped<IUserRepositry, UserRepositry>();
            builder.Services.AddScoped<ISkillRepository, SkillRepository>();
            builder.Services.AddScoped<ITeamRepository, TeamRepository>();
            builder.Services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IDeveloperSkillRepository, DeveloperSkillRepository>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IReviewTeamRepository, ReviewTeamRepository>();
            builder.Services.AddScoped<IReviewDevRepository, ReviewDevRepository>();
            builder.Services.AddScoped<IFeedBackOnClientRepository, FeedBackOnClientRepository>();
            builder.Services.AddScoped<IDeveloperRepositry, DeveloperRepositry>();
            builder.Services.AddScoped<IProjectServieces, ProjectServieces>();
            builder.Services.AddScoped<IProjectRepositry, ProjectRepositry>();
            builder.Services.AddScoped<IFeedBackOnClientService, FeedBackOnClientService>();
            builder.Services.AddScoped<IReviewTeamService, ReviewTeamService>();
            builder.Services.AddScoped<IReviewDeveloperService, ReviewDeveloperService>();
            builder.Services.AddScoped<IDeveloperSkillService, DeveloperSkillService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<ITeamService, TeamService>();
            builder.Services.AddScoped<ISkillService, SkillService>();
            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<ITeamMemberService, TeamMemberService>();
            builder.Services.AddScoped<IJointService, JointService>();
            builder.Services.AddScoped<ITeamService, TeamService>();
            builder.Services.AddScoped<ISkillService, SkillService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IDeveloperServices, DeveloperServices>();

            builder.Services.AddScoped<IRequestService, RequestService>();
            builder.Services.AddScoped<IClientRequestDeveloperRepository, ClientRequestDeveloperRepository>();
            builder.Services.AddScoped<IClientRequestTeamRepository, ClientRequestTeamRepository>();

            // Register EmailSettings and EmailService
          //  builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

            builder.Services.AddScoped<IEmailService, EmailService>();


            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, // You can set this to true if you want to validate the issuer.
                    ValidateAudience = false, // You can set this to true if you want to validate the audience.
                    ValidateLifetime = true, // Ensures the token hasn't expired.
                    ValidateIssuerSigningKey = true, // Ensures the token is properly signed.
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)) // Match with your token generation key.
                };
            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer <token>')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();


        }
    }
}
