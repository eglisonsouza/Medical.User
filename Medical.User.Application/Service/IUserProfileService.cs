using Medical.User.Application.Models.InputModels;
using Medical.User.Application.Models.ViewModels;

namespace Medical.User.Application.Service
{
    public interface IUserProfileService
    {
        Task<UserViewModel> AddAsync(UserInputModel model);
        Task<TokenViewModel> LoginAsync(LoginInputModel model);
        void Update(Guid id, UserInputModel model);
    }
}
