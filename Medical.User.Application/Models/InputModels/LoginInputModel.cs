using Medical.User.Domain.Models.Enuns;

namespace Medical.User.Application.Models.InputModels
{
    public sealed class LoginInputModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleType Role { get; set; }
    }
}
