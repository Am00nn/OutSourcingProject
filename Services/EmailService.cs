﻿using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using OutsourcingSystem.Configurations;
using DocuSign.eSign.Model;

namespace OutsourcingSystem.Services
{
    public class EmailService : IEmailService
    {
        private readonly Configurations.EmailSettings _emailSettings;

        public EmailService(IOptions<Configurations.EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string recipientEmail, string subject, string message)
        {
            var smtpClient = new SmtpClient(_emailSettings.SMTPHost)
            {
                Port = _emailSettings.Port,
                Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.Password),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.SenderEmail),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(recipientEmail);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error sending email: {ex.Message}");
            }
        }




    }





}
