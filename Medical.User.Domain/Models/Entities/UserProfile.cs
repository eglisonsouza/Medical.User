using Medical.User.Domain.Models.Enuns;

namespace Medical.User.Domain.Models.Entities
{
    public class UserProfile(string username, string password, string urlProfile, RoleType role, string email)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Username { get; private set; } = username;
        public string Password { get; private set; } = password;
        public string Email { get; private set; } = email;
        public string UrlProfile { get; private set; } = urlProfile;
        public RoleType Role { get; private set; } = role;
    }
}
