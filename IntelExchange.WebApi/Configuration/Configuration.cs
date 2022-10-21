using IntelExchange.DataModels.Enums;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace IntelExchange.WebApi.Configuration
{
    public class Configuration
    {
        public static Action<AuthorizationOptions> ConfigureAuthorization = (options) =>
        {
            options.AddPolicy("AdminPermission", policy =>
            {
                policy.RequireClaim("Permission", UserRole.Admin.ToString());
            });
            options.AddPolicy("CreatorPermission", policy =>
            {
                policy.RequireClaim("Permission", UserRole.TraderCreator.ToString());
            });
            options.AddPolicy("ObserverPermission", policy =>
            {
                policy.RequireClaim("Permission", UserRole.Observer.ToString());
            });
        };

        public static Action<CookieAuthenticationOptions> ConfigureCookies = (options) =>
        {
            options.LoginPath = new PathString("/account/login");
            options.LogoutPath = new PathString("/account/logout");
            options.Cookie.HttpOnly = false;
            options.Cookie.SameSite = SameSiteMode.None;
        };

        public static Action<CorsOptions> ConfigureCors = (options) =>
        {
            options.AddPolicy(name: "defaultPolicy",
                     policy =>
                     {
                         policy
                         .WithOrigins("http://localhost:3000", "https://localhost:3000")
                         .AllowCredentials()
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                     });
        };

    }
}
