using System;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Unikreativ.Helper.Confirm
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public class MessageServices : IEmailSender, ISmsSender
    {
        public IConfigurationRoot Configuration { get; }

        public MessageServices()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public Task SendEmail(string emailType, string to, object options)
        {
            var smtpServer = Configuration["Email:Server"];
            var smtpPortNumber = int.Parse(Configuration["Email:Port"]);
            try
            {
                string fromEmail, fromEmailTitle, toEmail, toEmailTitle, subject, bodyContent;
                if (emailType == "NewAccount")
                {
                    fromEmail = Configuration["Email:From"];
                    fromEmailTitle = "Account Register Confirmation";
                    toEmail = to;
                    toEmailTitle = "Account Register Confirmation";
                    subject = $"{to} - Account Register Confirmation";
                    bodyContent = $"Welcome to Unikreative teamwork please follow this link http://localhost:60876/Account/Confirm?emailTo={to}&token={options}/ to activate your account";
                }
                else
                {
                    fromEmail = Configuration["Email:From"];
                    fromEmailTitle = "Password Reset";
                    toEmail = to;
                    toEmailTitle = "Password Reset";
                    subject = $"{to} - Password Reset";
                    bodyContent = $"We receive your request to reset password. Follow this link http://localhost:60876/Account/Reset?emailTo={to}&token={options}/ to update new password";
                }

                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(fromEmailTitle, fromEmail));
                mimeMessage.To.Add(new MailboxAddress(toEmailTitle, toEmail));
                mimeMessage.Subject = subject;
                mimeMessage.Body = new TextPart("plain")
                {
                    Text = bodyContent
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(smtpServer, smtpPortNumber, false);
                    client.Authenticate(
                        Configuration["Email:Usermail"],
                        Configuration["Email:Password"]);
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}