using System.ComponentModel.DataAnnotations;

namespace Conductor.Api.Controllers
{
    public class RegisterDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 12)]
        public string Password { get; set; }
    }
}
