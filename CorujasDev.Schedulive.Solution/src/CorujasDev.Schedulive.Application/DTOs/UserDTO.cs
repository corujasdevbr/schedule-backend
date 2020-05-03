using CorujasDev.Schedulive.Core.DomainObjects;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CorujasDev.Schedulive.Application.DTOs
{
    public class UserDTO : Entity
    {
        [Required(ErrorMessage = "Firstname is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Firstname is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(16, MinimumLength = 8)]
        [JsonIgnore]
        public string Password { get; set; }

        [Required(ErrorMessage = "TypeUser is required")]
        public string TypeUser { get; set; }

        public UserDTO(string firstName, string email, string password, string typeUser)
        {
            FirstName = firstName;
            Email = email;
            Password = password;
            TypeUser = typeUser;
        }
    }
}
