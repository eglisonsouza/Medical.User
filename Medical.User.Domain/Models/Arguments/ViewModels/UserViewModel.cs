using Medical.User.Domain.Models.Arguments.BaseModels;
using Medical.User.Domain.Models.Entities;

namespace Medical.User.Domain.Models.Arguments.ViewModels
{
    public class UserViewModel : UserBaseModel
    {
        public Guid Id { get; set; }

        public static UserViewModel FromEntity(UserProfile entity)
        {
            return new UserViewModel
            {
                Id = entity.Id,
                Username = entity.Username,
                UrlProfile = entity.UrlProfile,
                Role = entity.Role,
                Email = entity.Email
            };
        }
    }
}
