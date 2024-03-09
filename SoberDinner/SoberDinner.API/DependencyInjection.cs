using Microsoft.AspNetCore.Mvc.Infrastructure;
using SoberDinner.API.Common.Errors;
using SoberDinner.API.Common.Mapping;

namespace SoberDinner.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {

            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, SoberProblemDetailsFactory>();

            services.AddMappings();
            return services;
        }
    }
}
