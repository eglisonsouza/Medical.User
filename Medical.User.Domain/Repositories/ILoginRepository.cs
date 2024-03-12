using Medical.User.Domain.Models.Arguments.ViewModels;
using Medical.User.Domain.Models.Entities;

namespace Medical.User.Domain.Repositories
{
    public interface ILoginRepository
    {
        Task<UserViewModel> LoginAsync(UserProfile user);
    }
}
