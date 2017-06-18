using System.Threading.Tasks;

namespace Unikreativ.Helper.Confirm
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}