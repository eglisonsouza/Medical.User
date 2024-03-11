using Medical.User.Domain.Models.Enuns;

namespace Medical.User.Domain.Models.Entities
{
    public class UserProfile
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string UrlProfile { get; private set; }
        public RoleType Role { get; private set; }
    }
}
