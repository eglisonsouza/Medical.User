using Medical.User.Domain.Common.Models;

namespace Medical.User.Domain.Common.Repositories
{
    public interface IAddRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync<TInputModel>(TInputModel entity) where TInputModel : ICommonInputModel<TEntity>;
    }
}
