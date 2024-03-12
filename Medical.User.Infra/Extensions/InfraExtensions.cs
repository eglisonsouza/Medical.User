using Medical.User.Domain.Common.Repositories;
using Medical.User.Domain.Repositories;
using Medical.User.Domain.Services;
using Medical.User.Infra.Persistence;
using Medical.User.Infra.Persistence.Configurations;
using Medical.User.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Medical.User.Infra.Extensions
{
    public static class InfraExtensions
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddRepositories();
            return services;
        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlServerDbContext>(options =>
                options.UseSqlServer(configuration.GetSection("Settings").GetConnectionString("SqlServerConnection"),
                    b => b.MigrationsAssembly(typeof(SqlServerDbContext).Assembly.FullName)));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped(typeof(IAddRepository<>), typeof(GenericRepository<>));
        }
    }
}
