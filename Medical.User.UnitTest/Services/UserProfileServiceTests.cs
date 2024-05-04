using AutoMapper;
using Medical.User.Application.Models.ViewModels;
using Medical.User.Application.Service;
using Medical.User.Domain.Constraints;
using Medical.User.Domain.Models.Entities;
using Medical.User.Domain.Repositories;
using Medical.User.UnitTest.Mock;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Smart.Essentials.Core.ResultDataModel;

namespace Medical.User.UnitTest.Services
{
    public sealed class UserProfileServiceTests
    {
        private readonly IUserRepository _repository;
        private readonly UserProfileService _service;
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        public UserProfileServiceTests()
        {
            _repository = Substitute.For<IUserRepository>();
            _mapper = Substitute.For<IMapper>();
            _notificationContext = new NotificationContext();
            _service = new UserProfileService(_repository, _mapper, _notificationContext);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnUserViewModel_WhenUsernameDoesNotExist()
        {
            // Arrange
            var model = UserMocks.GetUserInputModel();
            _repository.IsUsernameExist(model.Username).Returns(false);
            _repository.AddAsync(Arg.Any<UserProfile>()).Returns(UserMocks.GetUserEntity());
            _mapper.Map<UserViewModel>(Arg.Any<UserProfile>()).Returns(UserMocks.GetUserViewModel());
            // Act
            var result = await _service.AddAsync(model);

            // Assert
            _repository.Received(1).IsUsernameExist(Arg.Any<string>());
            await _repository.Received(1).AddAsync(Arg.Any<UserProfile>());

            Assert.NotNull(result);
            Assert.IsType<UserViewModel>(result);
            Assert.Empty(_notificationContext.Errors);
        }

        [Fact]
        public async Task AddAsync_ShouldException_WhenUsernameIsExist()
        {
            // Arrange
            var model = UserMocks.GetUserInputModel();
            _repository.IsUsernameExist(model.Username).Returns(true);
            _repository.AddAsync(Arg.Any<UserProfile>()).Returns(UserMocks.GetUserEntity());

            //Act
            var result = await _service.AddAsync(model);

            // Assert
            _repository.Received(1).IsUsernameExist(Arg.Any<string>());
            await _repository.Received(0).AddAsync(Arg.Any<UserProfile>());
            Assert.Null(result);
            Assert.NotEmpty(_notificationContext.Errors);
            Assert.Equal(ExceptionsMessages.UsernameIsInvalid, _notificationContext.Errors[0]);
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnTokenViewModel_WhenValidCredentialsAreProvided()
        {
            // Arrange
            var model = UserMocks.GetLoginInputModel();
            _repository.LoginAsync(Arg.Any<UserProfile>()).Returns(UserMocks.GetUserEntity());

            // Act
            var result = await _service.LoginAsync(model);

            // Assert
            await _repository.Received(1).LoginAsync(Arg.Any<UserProfile>());
            Assert.NotNull(result);
            Assert.IsType<TokenViewModel>(result);
            Assert.Empty(_notificationContext.Errors);
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnException_WhenInvalidCredentialsAreProvided()
        {
            // Arrange
            var model = UserMocks.GetLoginInputModel();
            _repository.LoginAsync(Arg.Any<UserProfile>()).ReturnsNull();

            //Act
            var result = await _service.LoginAsync(model);

            // Assert
            await _repository.Received(1).LoginAsync(Arg.Any<UserProfile>());
            Assert.Null(result);
            Assert.NotEmpty(_notificationContext.Errors);
            Assert.Equal(ExceptionsMessages.UsernameOrPasswordIsInvalid, _notificationContext.Errors[0]);
        }

        [Fact]
        public void Update_ShouldCallRepositoryUpdate_WhenValidIdAndModelAreProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = UserMocks.GetUserInputModel();

            // Act
            _service.Update(id, model);

            // Assert
            _repository.Received(1).Update(id, Arg.Any<UserProfile>());
            Assert.Empty(_notificationContext.Errors);
        }
    }

}
