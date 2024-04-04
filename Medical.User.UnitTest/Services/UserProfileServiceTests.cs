using Medical.User.Application.Service;
using Medical.User.Domain.Models.Entities;
using Medical.User.Domain.Repositories;
using Medical.User.UnitTest.Mock;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Smart.Essentials.Core.ResultDataModel;

namespace Medical.User.UnitTest.Services
{
    public class UserProfileServiceTests
    {
        private readonly IUserRepository _repository;
        private readonly UserProfileService _service;

        public UserProfileServiceTests()
        {
            _repository = Substitute.For<IUserRepository>();
            _service = new UserProfileService(_repository);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnUserViewModel_WhenUsernameDoesNotExist()
        {
            // Arrange
            var model = UserMocks.GetUserInputModel();
            _repository.IsUsernameExist(model.Username).Returns(false);
            _repository.AddAsync(Arg.Any<UserProfile>()).Returns(UserMocks.GetUserEntity());

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            _repository.Received(1).IsUsernameExist(Arg.Any<string>());
            await _repository.Received(1).AddAsync(Arg.Any<UserProfile>());
            Assert.NotNull(result);
            Assert.IsType<ResultModel>(result);
            Assert.True(result.IsSuccess);
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
            Assert.NotNull(result);
            Assert.IsType<ResultModel>(result);
            Assert.False(result.IsSuccess);
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
            Assert.IsType<ResultModel>(result);
            Assert.True(result.IsSuccess);
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
            Assert.NotNull(result);
            Assert.IsType<ResultModel>(result);
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public void Update_ShouldCallRepositoryUpdate_WhenValidIdAndModelAreProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = UserMocks.GetUserInputModel();

            // Act
            var result = _service.Update(id, model);

            // Assert
            _repository.Received(1).Update(id, Arg.Any<UserProfile>());
            Assert.NotNull(result);
            Assert.IsType<ResultModel>(result);
            Assert.True(result.IsSuccess);
        }
    }

}
