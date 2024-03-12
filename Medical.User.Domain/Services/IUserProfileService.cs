using Medical.User.Domain.Models.Arguments.InputModels;
using Medical.User.Domain.Models.Arguments.ViewModels;

namespace Medical.User.Domain.Services
{
    public interface IUserProfileService
    {
        Task<UserViewModel> AddAsync(UserInputModel model);
        Task<LoginViewModel> Login(LoginInputModel model);
    }
}
