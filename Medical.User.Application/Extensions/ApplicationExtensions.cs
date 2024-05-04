using Medical.User.Application.Models.Mappings;
using Medical.User.Application.Service;
using Microsoft.Extensions.DependencyInjection;
using Smart.Essentials.Core.ResultDataModel;
using System.Diagnostics.CodeAnalysis;

namespace Medical.User.Application.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMapping();
            services.AddScoped<NotificationContext>();
            services.AddScoped<IUserProfileService, UserProfileService>();
            return services;
        }

        private static void AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<UserMapping>();
            });
        }
    }
}
