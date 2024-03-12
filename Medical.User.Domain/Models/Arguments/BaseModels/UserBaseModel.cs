using Medical.User.Domain.Models.Enuns;

namespace Medical.User.Domain.Models.Arguments.BaseModels
{
    public class UserBaseModel
    {
        public string Username { get; set; }
        public string UrlProfile { get; set; }
        public RoleType Role { get; set; }
    }
}
