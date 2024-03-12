using Medical.User.Domain.Common.Repositories;
using Medical.User.Domain.Models.Arguments.InputModels;
using Medical.User.Domain.Models.Arguments.ViewModels;
using Medical.User.Domain.Models.Entities;
using Medical.User.Domain.Services;
using Smart.Essentials.Security;

namespace Medical.User.Application.Service
{
    public class UserProfileService(
        IAddRepository<UserProfile> addRepository,
        ILoginRepository<UserProfile> loginRepository
        ) : IUserProfileService
    {
        private readonly IAddRepository<UserProfile> _addRepository = addRepository;
        private readonly ILoginRepository<UserProfile> _loginRepository = loginRepository;

        public async Task<UserViewModel> AddAsync(UserInputModel model)
        {
            model.Password = PasswordService.ComputeSha256Hash(model.Password);

            var entity = await _addRepository.AddAsync(model);

            return UserViewModel.FromEntity(entity);
        }

        public async Task<LoginViewModel> Login(LoginInputModel model)
        {
            var entity = await _loginRepository.LoginAsync(model);

            return new LoginViewModel();
        }
    }
}
