
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






            builder.Services.AddControllers();

            builder.Services.AddScoped<IUserRepositry, UserRepositry>();
            builder.Services.AddScoped<ISkillRepository, SkillRepository>();
            builder.Services.AddScoped<ITeamRepository, TeamRepository>();
            builder.Services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IDeveloperSkillRepository, DeveloperSkillRepository>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();

            builder.Services.AddScoped<IDeveloperSkillService, DeveloperSkillService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<ITeamService, TeamService>();
            builder.Services.AddScoped<ISkillService, SkillService>();
            //builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<ITeamMemberService, TeamMemberService>();
            builder.Services.AddScoped<IJointService, JointService>();
            builder.Services.AddScoped<ITeamService, TeamService>();
            builder.Services.AddScoped<ISkillService, SkillService>();
            builder.Services.AddScoped<IClientService, ClientService>();





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
