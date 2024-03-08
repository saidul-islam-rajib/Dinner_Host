using Microsoft.Extensions.DependencyInjection;
using SoberDinner.Application.Services.Authentication;
using SoberDinner.Application.Services.Authentication.Commands;
using SoberDinner.Application.Services.Authentication.Queries;

namespace SoberDinner.Application.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
            return services;
        }
    }
}
