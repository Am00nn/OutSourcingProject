using DocuSign.eSign.Model;
using Microsoft.Extensions.Options;
using OutsourcingSystem.DTOs;
using System.Net.Mail;
using System.Net;

namespace OutsourcingSystem.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(EmailMessage message, string smtpUsername, string smtpPassword)
        {
            try
            {
                var emailSettings = _configuration.GetSection("EmailSettings");

                var smtpHost = emailSettings["SmtpHost"];

                var smtpPort = int.Parse(emailSettings["SmtpPort"]);

                var smtpClient = new SmtpClient(smtpHost, smtpPort)
                {
                    Credentials = new NetworkCredential(smtpUsername, smtpPassword),

                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(message.From),
                    Subject = message.Subject,
                    Body = message.Body,
                    IsBodyHtml = false
                };

                mailMessage.To.Add(message.To);

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while sending the email.", ex);
            }
        }
    }

}
