using Microsoft.Extensions.DependencyInjection;
using SoberDinner.Application.Common.Interfaces.Authentication;
using SoberDinner.Infrastructure.Authentication;

namespace SoberDinner.Infrastructure.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            return services;
        }
    }
}
