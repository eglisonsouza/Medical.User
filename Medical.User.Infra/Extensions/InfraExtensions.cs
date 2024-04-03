using Medical.User.Domain.Repositories;
using Medical.User.Infra.Persistence.Configurations;
using Medical.User.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smart.Essentials.HealthCheck.SqlServer.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Medical.User.Infra.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class InfraExtensions
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddHealthChecksInfra(configuration);
            services.AddRepositories();
            return services;
        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlServerDbContext>(options =>
                options.UseSqlServer(configuration.GetSection("Settings").GetConnectionString("SqlServerConnection"),
                    b => b.MigrationsAssembly(typeof(SqlServerDbContext).Assembly.FullName)));
        }

        private static void AddHealthChecksInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks().AddSqlServer(configuration.GetSection("Settings").GetConnectionString("SqlServerConnection")!);
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
