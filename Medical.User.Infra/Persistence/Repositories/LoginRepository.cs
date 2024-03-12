using Medical.User.Domain.Models.Arguments.ViewModels;
using Medical.User.Domain.Models.Entities;
using Medical.User.Domain.Repositories;
using Medical.User.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Medical.User.Infra.Persistence.Repositories
{
    public class LoginRepository(SqlServerDbContext context) : ILoginRepository
    {
        private readonly SqlServerDbContext _context = context;

        public async Task<UserViewModel> LoginAsync(UserProfile user)
        {
            var entity = await _context.Users.SingleAsync(u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password) && u.Role.Equals(user.Role));

            return UserViewModel.FromEntity(entity);
        }
    }
}
