using System.ComponentModel.DataAnnotations;

namespace Unikreativ.Entities.ViewModel
{
    public class Client
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Industry { get; set; }

        [Required]
        public string Website { get; set; }

        public double ChargeRate = 0;

        [Required]
        public string UserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}