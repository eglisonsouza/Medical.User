using Medical.User.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Medical.User.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserProfileService, UserProfileService>();
            return services;
        }
    }
}
