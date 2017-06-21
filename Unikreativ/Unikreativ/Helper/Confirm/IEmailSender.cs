using System.Threading.Tasks;
using Unikreativ.Entities.Models;

namespace Unikreativ.Helper.Confirm
{
    public interface IEmailSender
    {
        Task SendEmail(EmailType emailType, string to, object options);
    }
}