using System.Threading.Tasks;

namespace Unikreativ.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}