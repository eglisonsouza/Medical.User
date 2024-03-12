using Medical.User.Domain.Common.Repositories;
using Medical.User.Domain.Models.Arguments.InputModels;
using Medical.User.Domain.Models.Arguments.ViewModels;
using Medical.User.Domain.Models.Entities;
using Medical.User.Domain.Repositories;
using Medical.User.Domain.Services;
using Smart.Essentials.Security;

namespace Medical.User.Application.Service
{
    public class UserProfileService(
        IAddRepository<UserProfile> addRepository,
        ILoginRepository loginRepository
        ) : IUserProfileService
    {
        private readonly IAddRepository<UserProfile> _addRepository = addRepository;
        private readonly ILoginRepository _loginRepository = loginRepository;

        public async Task<UserViewModel> AddAsync(UserInputModel model)
        {
            model.Password = PasswordService.ComputeSha256Hash(model.Password);

            var entity = await _addRepository.AddAsync(model);

            return UserViewModel.FromEntity(entity);
        }

        public async Task<TokenViewModel> Login(LoginInputModel model)
        {
            var user = await _loginRepository.LoginAsync(model.ToEntity());

            var tokenDto = TokenService.GenerateToken(user.Email, user.Role.ToString(), user.Id, user.Username);

            return new TokenViewModel()
            {
                Email = user.Email,
                Role = user.Role,
                UrlProfile = user.UrlProfile,
                Username = user.Username,
                Token = tokenDto.Token,
                RefressToken = tokenDto.RefressToken
            };
        }

        public Task<UserViewModel> UpdateAsync(UserInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}
