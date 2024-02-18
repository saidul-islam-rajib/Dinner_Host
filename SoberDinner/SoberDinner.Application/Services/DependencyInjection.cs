using Microsoft.Extensions.DependencyInjection;
using SoberDinner.Application.Services.Authentication;

namespace SoberDinner.Application.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
