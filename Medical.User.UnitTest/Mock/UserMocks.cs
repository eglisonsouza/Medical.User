using Medical.User.Application.Models.InputModels;
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
            return new UserProfile("username", "password", "urlProfile", RoleType.Doctor, "email");
        }

        public static LoginInputModel GetLoginInputModel()
        {
            return new LoginInputModel { Username = "TestUser", Password = "TestPassword" };
        }
    }
}
