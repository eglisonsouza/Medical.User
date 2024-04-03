using Medical.User.Application.Models.ViewModels;
using Medical.User.Application.Service;
using Medical.User.Domain.Exceptions;
using Medical.User.Domain.Models.Entities;
using Medical.User.Domain.Repositories;
using Medical.User.UnitTest.Mock;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

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
            Assert.NotNull(result);
            Assert.IsType<UserViewModel>(result);
        }

        [Fact]
        public async Task AddAsync_ShouldException_WhenUsernameIsExist()
        {
            // Arrange
            var model = UserMocks.GetUserInputModel();
            _repository.IsUsernameExist(model.Username).Returns(true);
            _repository.AddAsync(Arg.Any<UserProfile>()).Returns(UserMocks.GetUserEntity());

            // Assert
            await Assert.ThrowsAsync<DomainException>(async () => await _service.AddAsync(model));
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
            Assert.NotNull(result);
            Assert.IsType<TokenViewModel>(result);
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnException_WhenInvalidCredentialsAreProvided()
        {
            // Arrange
            var model = UserMocks.GetLoginInputModel();
            _repository.LoginAsync(Arg.Any<UserProfile>()).ReturnsNull();

            // Act
            await Assert.ThrowsAsync<DomainException>(async () => await _service.LoginAsync(model));
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
        }
    }

}
