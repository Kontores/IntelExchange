using IntelExchange.DataModels;
using IntelExchange.WebApi.Validation;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace IntelExchange.WebApi.Configuration
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IValidator<UserLoginData>, LoginValidator>();
            return services;
        }
    }
}
