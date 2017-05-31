using System;
using System.Collections.Generic;
using System.Text;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Entities.ViewModel
{
    public class Member
    {
        public string Id { get; set; }
        public string NormalizedUserName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string JobTitle { get; set; }
        public List<string> UserRoles { get; set; }
    }
}