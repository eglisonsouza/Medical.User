using Medical.User.Application.Models.InputModels;
using Medical.User.Application.Models.ViewModels;
using Medical.User.Domain.Constraints;
using Medical.User.Domain.Exceptions;
using Medical.User.Domain.Repositories;
using Smart.Essentials.Security.Jwt;

namespace Medical.User.Application.Service
{
    public sealed class UserProfileService(IUserRepository repository) : IUserProfileService
    {
        private readonly IUserRepository _repository = repository;

        public async Task<UserViewModel> AddAsync(UserInputModel model)
        {
            if (_repository.IsUsernameExist(model.Username))
                throw new DomainException(ExceptionsMessages.UsernameIsInvalid);

            var entity = await _repository.AddAsync(model.ToEntity());

            return UserViewModel.FromEntity(entity);
        }

        public async Task<TokenViewModel> LoginAsync(LoginInputModel model)
        {
            var entity = await _repository.LoginAsync(model.ToEntity());

            var tokenDto = TokenService.GenerateToken(entity.Email, entity.Role.ToString(), entity.Id, entity.Username);

            return new TokenViewModel()
            {
                Email = entity.Email,
                Role = entity.Role,
                UrlProfile = entity.UrlProfile,
                Username = entity.Username,
                Token = tokenDto.Token,
                RefressToken = tokenDto.RefressToken
            };
        }

        public void Update(Guid id, UserInputModel model)
        {
            _repository.Update(id, model.ToEntity());
        }
    }
}
