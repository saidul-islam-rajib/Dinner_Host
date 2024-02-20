using Microsoft.Extensions.DependencyInjection;
using SoberDinner.Application.Common.Interfaces.Authentication;
using SoberDinner.Application.Common.Interfaces.Services;
using SoberDinner.Infrastructure.Authentication;

namespace SoberDinner.Infrastructure.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            Microsoft.Extensions.Configuration.ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName)); // Add ioption interface where we configured JwtSettings
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}
