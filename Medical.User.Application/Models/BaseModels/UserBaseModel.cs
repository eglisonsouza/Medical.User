using Medical.User.Domain.Models.Enuns;

namespace Medical.User.Application.Models.BaseModels
{
    public abstract class UserBaseModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string UrlProfile { get; set; }
        public RoleType Role { get; set; }
    }
}
