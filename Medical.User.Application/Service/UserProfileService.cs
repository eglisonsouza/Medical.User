using AutoMapper;
using Medical.User.Application.Models.InputModels;
using Medical.User.Application.Models.ViewModels;
using Medical.User.Domain.Constraints;
using Medical.User.Domain.Models.Entities;
using Medical.User.Domain.Repositories;
using Smart.Essentials.Core.ResultDataModel;
using Smart.Essentials.Security.Jwt;

namespace Medical.User.Application.Service
{
    public sealed class UserProfileService(IUserRepository repository, IMapper mapper) : IUserProfileService
    {
        private readonly IUserRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<ResultModel> AddAsync(UserInputModel model)
        {
            if (_repository.IsUsernameExist(model.Username))
                return ResultModel.WithErrors([ExceptionsMessages.UsernameIsInvalid]);

            var entity = await _repository.AddAsync(_mapper.Map<UserProfile>(model));

            return ResultModel.WithSuccessfully(_mapper.Map<UserViewModel>(entity));
        }

        public async Task<ResultModel> LoginAsync(LoginInputModel model)
        {
            var entity = await _repository.LoginAsync(_mapper.Map<UserProfile>(model));

            if (entity is null)
                return ResultModel.WithErrors([ExceptionsMessages.UsernameOrPasswordIsInvalid]);

            var tokenDto = TokenService.GenerateToken(entity.Email, entity.Role.ToString(), entity.Id, entity.Username);

            var tokenViewModel = new TokenViewModel()
            {
                Email = entity.Email,
                Role = entity.Role,
                UrlProfile = entity.UrlProfile,
                Username = entity.Username,
                Token = tokenDto.Token,
                RefressToken = tokenDto.RefressToken
            };

            return ResultModel.WithSuccessfully(tokenViewModel);
        }

        public ResultModel Update(Guid id, UserInputModel model)
        {
            _repository.Update(id, _mapper.Map<UserProfile>(model));

            return ResultModel.WithSuccessfully();
        }
    }
}
