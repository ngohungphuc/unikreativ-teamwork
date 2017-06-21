﻿using System;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Unikreativ.Entities.Models;

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

        public Task SendEmail(EmailType emailType, string to, object options)
        {
            var email = new Email
            {
                SmtpServer = Configuration["Email:Server"],
                SmtpPortNumber = int.Parse(Configuration["Email:Port"]),
                FromEmail = Configuration["Email:From"],
                ToEmail = to
            };
            try
            {
                switch (emailType)
                {
                    case EmailType.ClientAccount:
                        email.FromEmailTitle = "Account Register Confirmation";
                        email.ToEmailTitle = "Account Register Confirmation";
                        email.Subject = $"{to} - Account Register Confirmation";
                        email.BodyContent =
                            $"Welcome to Unikreative teamwork please follow this link http://localhost:60876/Account/Confirm?emailTo={to}&token={options}/ to activate your account";
                        break;

                    case EmailType.ResetPassword:
                        email.FromEmailTitle = "Password Reset";
                        email.ToEmailTitle = "Password Reset";
                        email.Subject = $"{to} - Password Reset";
                        email.BodyContent =
                             $"We receive your request to reset password. Follow this link http://localhost:60876/Account/Reset?emailTo={to}&token={options}/ to update new password";
                        break;
                }

                SendMailService(email);
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
                    Configuration["Email:Usermail"],
                    Configuration["Email:Password"]);
                client.Send(mimeMessage);
                client.Disconnect(true);
            }
        }
    }
}