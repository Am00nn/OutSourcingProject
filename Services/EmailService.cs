using System.Net.Mail;
using System.Net;

namespace OutsourcingSystem.Services
{
    public class EmailService
    {
        private static readonly string AdminEmail = "amanialshmali7@gmail.com";
        private static readonly string AppPassword = "vdim bqox zlbp mgyk";

        public static void SendEmail(string recipient, string subject, string body)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(AdminEmail, AppPassword),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(AdminEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(recipient);

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email sending failed: {ex.Message}");
            }
        }
    }
}
