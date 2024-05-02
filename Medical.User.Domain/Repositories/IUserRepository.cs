using Medical.User.Domain.Models.Entities;

namespace Medical.User.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<UserProfile> AddAsync(UserProfile entity);
        Task<UserProfile?> LoginAsync(UserProfile entity);
        void Update(Guid id, UserProfile entity);
        bool IsUsernameExist(string username);
    }
}
