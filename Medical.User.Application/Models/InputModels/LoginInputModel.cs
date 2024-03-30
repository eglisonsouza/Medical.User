using Medical.User.Domain.Models.Entities;
using Medical.User.Domain.Models.Enuns;
using Smart.Essentials.Security.Cryptography;

namespace Medical.User.Application.Models.InputModels
{
    public class LoginInputModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleType Role { get; set; }

        public UserProfile ToEntity()
        {
            return new UserProfile(Username, Password.To256Hash(), string.Empty, Role, string.Empty);
        }
    }
}
