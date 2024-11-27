using System.ComponentModel.DataAnnotations;

namespace AirlineCompensation.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Username must be supply!")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password must be supply!")]
        public string? Password { get; set; }

        public bool? Remember { get; set; }
    }
}
