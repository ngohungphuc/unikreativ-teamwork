using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Unikreativ.Entities.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }

        public string JobTitle { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string Website { get; set; }

        public double ChargeRate { get; set; }

        public string Status { get; set; }

        public string Industry { get; set; }

        //public enum Industry
        //{
        //    Technology = 1,
        //    Finance = 2,
        //    Ecommerce = 3,
        //    Healthcare = 4,
        //    Construction = 5,
        //    Other = 0
        //}
    }
}