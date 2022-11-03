using IntelExchange.DataModels;
using IntelExchange.DataModels.Enums;

namespace IntelExchange.WebApi.Models
{
    public record UserSignupModel(string Login, string Password, UserType UserType, UserProfile Profile): UserLoginModel(Login, Password);
}
