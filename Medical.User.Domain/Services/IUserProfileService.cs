using Medical.User.Domain.Models.Arguments.InputModels;
using Medical.User.Domain.Models.Arguments.ViewModels;

namespace Medical.User.Domain.Services
{
    public interface IUserProfileService
    {
        Task<UserViewModel> AddAsync(UserInputModel model);
        Task<TokenViewModel> Login(LoginInputModel model);
        void Update(Guid id, UserInputModel model);
    }
}
