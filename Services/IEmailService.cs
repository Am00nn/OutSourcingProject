using OutsourcingSystem.DTOs;

namespace OutsourcingSystem.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailMessage message, string smtpUsername, string smtpPassword);
    }
}