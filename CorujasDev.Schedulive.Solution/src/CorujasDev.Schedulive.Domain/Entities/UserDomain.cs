using CorujasDev.Schedulive.Core.DomainObjects;
using Flunt.Notifications;
using Flunt.Validations;

namespace CorujasDev.Schedulive.Domain.Entities
{
    public class UserDomain : Entity
    {
        public string FirstName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string TypeUser { get; set; }

        public UserDomain(string firstName, string email, string password, string typeUser)
        {

            AddNotifications(new Contract()
                .IsNotNullOrEmpty(firstName, "Firstname", "FirstName is required")
                .IsNotNullOrEmpty(email, "Email", "Email is required")
                .HasMinLen(password, 8, "Password", "Password should have at least 8 chars")
                .IsNotNullOrEmpty(typeUser, "TypeUser", "TypeUser is required")
            );

            if (Valid) { 
                FirstName = firstName;
                Email = email;
                Password = password;
                TypeUser = typeUser;
            }
        }
    }
}
