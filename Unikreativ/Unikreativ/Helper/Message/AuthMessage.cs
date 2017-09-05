using Newtonsoft.Json;
using Unikreativ.Entities.Models.Auth;

namespace Unikreativ.Helper.Message
{
    public static class AccountValidate
    {
        public static string ValidationMessage(RequestState state, string message)
        {
            return JsonConvert.SerializeObject(new RequestResult
            {
                State = state,
                Msg = message
            });
        }
    }
}