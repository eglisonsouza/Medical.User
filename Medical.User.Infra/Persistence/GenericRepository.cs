using Medical.User.Domain.Common.Models;
using Medical.User.Domain.Common.Repositories;
using Medical.User.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Medical.User.Infra.Persistence
{
    public class GenericRepository<TEntity> : IAddRepository<TEntity>
        where TEntity : class

    {
        private readonly SqlServerDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(SqlServerDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync<TInputModel>(TInputModel model) where TInputModel : ICommonInputModel<TEntity>
        {
            var result = await _dbSet.AddAsync(model.ToEntity());
            _context.SaveChanges();

            return result.Entity;
        }
    }
}
