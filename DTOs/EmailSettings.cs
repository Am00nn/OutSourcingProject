namespace OutsourcingSystem.DTOs
{
    public class EmailSettings
    {
        public string SmtpHost { get; set; }       //  SMTP
        public int SmtpPort { get; set; }          // port SMTP
        public string DefaultSenderEmail { get; set; } 
    }

}
