namespace Unikreativ.Entities.Models
{
    public class Email
    {
        public string SmtpServer { get; set; }
        public int SmtpPortNumber { get; set; }
        public string FromEmail { get; set; }
        public string FromEmailTitle { get; set; }
        public string ToEmail { get; set; }
        public string ToEmailTitle { get; set; }
        public string Subject { get; set; }
        public string BodyContent { get; set; }
    }

    public enum EmailType
    {
        ClientAccount,
        ResetPassword,
        MemberAccount
    }
}