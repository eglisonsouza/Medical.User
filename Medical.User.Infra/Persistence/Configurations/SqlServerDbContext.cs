using Medical.User.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medical.User.Infra.Persistence.Configurations
{
    public class SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : DbContext(options)
    {
        public DbSet<UserProfile> Users { get; set; }
        public DbSet<AccessHistory> AccessHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerDbContext).Assembly);
        }
    }
}
