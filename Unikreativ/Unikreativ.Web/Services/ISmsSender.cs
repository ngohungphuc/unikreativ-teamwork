using System.Threading.Tasks;

namespace Unikreativ.Web.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
