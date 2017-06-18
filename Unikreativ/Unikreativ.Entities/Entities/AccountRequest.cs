using System;
using System.ComponentModel.DataAnnotations;

namespace Unikreativ.Entities.Entities
{
    public class AccountRequest
    {
        [Key]
        public Guid RequestId { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime RequestTime { get; set; }
        public int ExpireTime { get; set; }
    }
}