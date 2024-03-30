using Medical.User.Domain.Models.Entities;
using Medical.User.Domain.Repositories;
using Medical.User.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Smart.Essentials.Security.Cryptography;

namespace Medical.User.Infra.Persistence.Repositories
{
    public sealed class UserRepository(SqlServerDbContext context) : IUserRepository
    {
        private readonly SqlServerDbContext _context = context;

        public async Task<UserProfile> AddAsync(UserProfile entity)
        {            
            var result = await _context.Users.AddAsync(entity);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public Task<UserProfile> LoginAsync(UserProfile entity)
        {
            return _context.Users.SingleAsync(u => u.Username.Equals(entity.Username) && u.Password.Equals(entity.Password) && u.Role.Equals(entity.Role));
        }

        public void Update(Guid id, UserProfile entity)
        {
            _context.Users
               .Where(p => p.Id.Equals(id))
               .ExecuteUpdate(
                setters =>
                setters
                   .SetProperty(p => p.Username, entity.Username)
                   .SetProperty(p => p.Password, entity.Password.To256Hash())
                   .SetProperty(p => p.Email, entity.Email)
                   .SetProperty(p => p.UrlProfile, entity.UrlProfile)
                   .SetProperty(p => p.Role, entity.Role)
               );
        }

        public bool IsUsernameExist(string username)
        {
            return _context.Users.Where(u => u.Username.Equals(username)).Count() > 0;
        }
    }
}
