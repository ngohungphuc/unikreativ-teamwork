using System;

namespace Unikreativ.Entities.Models.Auth
{
    public class RequestResult
    {
        public RequestState State { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }

    public enum RequestState
    {
        Failed = -1,
        NotAuth = 0,
        Success = 1
    }
}