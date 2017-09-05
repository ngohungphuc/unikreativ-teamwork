using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Unikreativ.Entities.Models;
using Unikreativ.Helper.Config;

namespace Unikreativ.Helper.Confirm
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public class MessageServices : IEmailSender, ISmsSender
    {
        public Task SendEmail(EmailType emailType, string to, string bodyContent)
        {
            var email = new Email
            {
                SmtpServer = ConfigReader.GetConfigFile()["Email:Server"],
                SmtpPortNumber = int.Parse(ConfigReader.GetConfigFile()["Email:Port"]),
                FromEmail = ConfigReader.GetConfigFile()["Email:From"],
                ToEmail = to,
                BodyContent = bodyContent
            };

            switch (emailType)
            {
                case EmailType.ClientAccount:
                case EmailType.MemberAccount:
                    email.FromEmailTitle = "Account Register Confirmation";
                    email.ToEmailTitle = "Account Register Confirmation";
                    email.Subject = $"{to} - Account Register Confirmation";
                    break;

                case EmailType.ResetPassword:
                    email.FromEmailTitle = "Password Reset";
                    email.ToEmailTitle = "Password Reset";
                    email.Subject = $"{to} - Password Reset";
                    break;

                default:
                    break;
            }

            SendMailService(email);
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }

        private void SendMailService(Email email)
        {
            var mimeMessage = new MimeMessage();

            mimeMessage.From.Add(new MailboxAddress(email.FromEmailTitle, email.FromEmail));
            mimeMessage.To.Add(new MailboxAddress(email.ToEmailTitle, email.ToEmail));
            mimeMessage.Subject = email.Subject;
            mimeMessage.Body = new TextPart("plain")
            {
                Text = email.BodyContent
            };

            using (var client = new SmtpClient())
            {
                client.Connect(email.SmtpServer, email.SmtpPortNumber, false);
                client.Authenticate(
                    ConfigReader.GetConfigFile()["Email:Usermail"],
                    ConfigReader.GetConfigFile()["Email:Password"]);
                client.Send(mimeMessage);
                client.Disconnect(true);
            }
        }
    }
}