using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Unikreativ.Entities.Entities
{
    public class Client : BaseUser
    {
        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string Website { get; set; }

        public enum Industry
        {
            Technology = 1,
            Finance = 2,
            Ecommerce = 3,
            Healthcare = 4,
            Construction = 5,
            Other = 0
        }
    }
}