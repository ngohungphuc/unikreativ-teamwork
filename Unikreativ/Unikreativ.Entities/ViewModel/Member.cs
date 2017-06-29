using System.Collections.Generic;

namespace Unikreativ.Entities.ViewModel
{
    public class Member
    {
        public string Id { get; set; }
        public string NormalizedUserName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string JobTitle { get; set; }
        public double ChargeRate { get; set; }
        private readonly bool EmailConfirmed = false;
    }
}