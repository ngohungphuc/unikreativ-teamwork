using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Unikreativ.Helper.Confirm;
using Microsoft.Extensions.Configuration;

namespace Unikreativ.Helper.Email
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public class MessageServices : IEmailSender, ISmsSender
    {
        public MessageServices(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }

        public IConfigurationRoot Configuration { get; }

        public Task SendEmail(string emailType, string to, object options)
        {
            var smtpServer = Configuration.GetSection("Email:Server").ToString();
            var smtpPortNumber = int.Parse(Configuration.GetSection("Email:Port").ToString());
            try
            {
                string fromEmail, fromEmailTitle, toEmail, toEmailTitle, subject, bodyContent;
                if (emailType == "NewAccount")
                {
                    fromEmail = Configuration.GetSection("Email:From").ToString();
                    fromEmailTitle = "Account Register Confirmation";
                    toEmail = to;
                    toEmailTitle = "Account Register Confirmation";
                    subject = $"{to} - Account Register Confirmation";
                    bodyContent = $"Welcome to Unikreative teamwork please follow this link <a href='http://localhost:60876/Account/Confirm/{to}/{options}'>link</a> to activate your account";
                }
                else
                {
                    fromEmail = Configuration.GetSection("Email:From").ToString();
                    fromEmailTitle = "Password Reset";
                    toEmail = to;
                    toEmailTitle = "Password Reset";
                    subject = $"{to} - Password Reset";
                    bodyContent = $"We receive your request to reset password. Follow this link <a href='http://localhost:60876/Account/Reset/{to}/{options}'>link</a> to update new password";
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
                        Configuration.GetSection("Email:Usermail").ToString(),
                        Configuration.GetSection("Email:Password").ToString());
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