using IntelExchange.DataModels;
using IntelExchange.WebApi.Validation;

namespace IntelExchange.WebApi.Configuration
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<UserLoginData>, LoginValidator>();
            return services;
        }
    }
}
