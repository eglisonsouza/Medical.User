using Medical.User.Application.Models.InputModels;
using Medical.User.Application.Models.ViewModels;
using Medical.User.Domain.Models.Entities;
using Medical.User.Domain.Models.Enuns;

namespace Medical.User.UnitTest.Mock
{
    public static class UserMocks
    {
        public static UserInputModel GetUserInputModel()
        {
            return new UserInputModel
            {
                Username = "TestUser",
                Password = "admin123",
                Email = "email@email.com",
                UrlProfile = "",
                Role = RoleType.Doctor
            };
        }

        public static UserProfile GetUserEntity()
        {
            return new UserProfile
            {
                Email = "eglison.souza@gmail.com",
                Password = "289160db0d9f39f9ae1754c4ec9c16f90b50e32e09c5fb5481ae642b3d3d1a36",
                Role = RoleType.Doctor,
                Username = "eglisonsouza"
            };
        }

        public static LoginInputModel GetLoginInputModel()
        {
            return new LoginInputModel { Username = "TestUser", Password = "TestPassword", Role = RoleType.Doctor };
        }

        public static UserViewModel GetUserViewModel()
        {
            return new UserViewModel()
            {
                Email = "eglison.souza@gmail.com",
                Role = RoleType.Doctor,
                Username = "eglisonsouza",
                Id = Guid.NewGuid(),
                UrlProfile = "url"
            };
        }
    }
}
