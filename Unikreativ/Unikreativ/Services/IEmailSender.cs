using System.Threading.Tasks;

namespace Unikreativ.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}