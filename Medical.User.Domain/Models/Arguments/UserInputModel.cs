using Medical.User.Domain.Common.Models;
using Medical.User.Domain.Models.Entities;

namespace Medical.User.Domain.Models.Arguments
{
    public class UserInputModel : ICommonInputModel<UserInputModel, UserProfile>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UrlProfile { get; set; }

        public UserProfile ToEntity(UserInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}
