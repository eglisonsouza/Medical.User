using Medical.User.Domain.Models.Arguments.BaseModels;
using Medical.User.Domain.Models.Entities;

namespace Medical.User.Domain.Models.Arguments.InputModels
{
    public class UserInputModel : UserBaseModel
    {
        public string Password { get; set; }

        public UserProfile ToEntity()
        {
            return new UserProfile(Username, Password, UrlProfile, Role, Email);
        }
    }
}
