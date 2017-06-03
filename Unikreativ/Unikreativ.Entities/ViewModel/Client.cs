using System;
using System.Collections.Generic;
using System.Text;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Entities.ViewModel
{
    public class Client
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public User.Industry Industries { get; set; }
        public string Website { get; set; }
    }
}