﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unikreativ.Entities.Models.Auth;

namespace Unikreativ.Helper.Message
{
    public static class AccountValidate
    {
        public static string ValidationMessage(string message)
        {
            return JsonConvert.SerializeObject(new RequestResult
            {
                State = RequestState.Failed,
                Msg = message
            });
        }
    }
}