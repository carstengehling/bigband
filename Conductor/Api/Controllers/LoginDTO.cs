using System.ComponentModel.DataAnnotations;

namespace Conductor.Api.Controllers
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
