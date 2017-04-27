﻿using System.Threading.Tasks;

namespace Unikreativ.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
