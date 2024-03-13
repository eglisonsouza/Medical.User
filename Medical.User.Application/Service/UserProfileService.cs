using Medical.User.Domain.Models.Arguments.InputModels;
using Medical.User.Domain.Models.Arguments.ViewModels;
using Medical.User.Domain.Services;
using Medical.User.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Smart.Essentials.Security.Cryptography;
using Smart.Essentials.Security.Jwt;

namespace Medical.User.Application.Service
{
    public class UserProfileService(SqlServerDbContext context) : IUserProfileService
    {
        private readonly SqlServerDbContext _context = context;

        public async Task<UserViewModel> AddAsync(UserInputModel model)
        {
            model.Password = PasswordService.ComputeSha256Hash(model.Password);

            var result = await _context.Users.AddAsync(model.ToEntity());

            await _context.SaveChangesAsync();

            return UserViewModel.FromEntity(result.Entity);
        }

        public async Task<TokenViewModel> Login(LoginInputModel model)
        {
            var entity = await _context.Users.SingleAsync(u => u.Username.Equals(model.Username) && u.Password.Equals(model.Password) && u.Role.Equals(model.Role));

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
            _context.Users
               .Where(p => p.Id.Equals(id))
               .ExecuteUpdate(
                setters =>
                setters
                   .SetProperty(p => p.Username, model.Username)
                   .SetProperty(p => p.Password, model.Password)
                   .SetProperty(p => p.Email, model.Email)
                   .SetProperty(p => p.UrlProfile, model.UrlProfile)
                   .SetProperty(p => p.Role, model.Role)
               );
        }
    }
}
