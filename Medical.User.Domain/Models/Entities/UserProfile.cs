using Medical.User.Domain.Models.Enuns;

namespace Medical.User.Domain.Models.Entities
{
    public sealed class UserProfile()
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UrlProfile { get; set; }
        public RoleType Role { get; set; }
    }
}
