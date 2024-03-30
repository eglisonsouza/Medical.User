using Medical.User.Application.Models.BaseModels;
using Medical.User.Domain.Models.Entities;
using Smart.Essentials.Security.Cryptography;

namespace Medical.User.Application.Models.InputModels
{
    public class UserInputModel : UserBaseModel
    {
        public string Password { get; set; }

        public UserProfile ToEntity()
        {
            return new UserProfile(Username, Password.To256Hash(), UrlProfile, Role, Email);
        }
    }
}
