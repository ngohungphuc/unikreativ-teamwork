using System.Threading.Tasks;

namespace Unikreativ.Helper.Confirm
{
    public interface IEmailSender
    {
        Task SendEmail(string emailType, string to, object options);
    }
}