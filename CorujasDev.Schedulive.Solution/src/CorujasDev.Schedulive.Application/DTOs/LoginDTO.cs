using System.ComponentModel.DataAnnotations;

namespace CorujasDev.Schedulive.Application.DTOs
{
    public class LoginDTO
    {
        [EmailAddress(ErrorMessage = "Firstname is required")]
        public string Email { get;  set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(16, MinimumLength = 8)]
        public string Password { get;  set; }
    }
}
