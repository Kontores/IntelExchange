using IntelExchange.DataModels;
using IntelExchange.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IntelExchange.WebApi.Validation
{
    public class LoginValidator : IValidator<UserLoginData>
    {
        private readonly IUserService _userService;
        private User? user;
        public LoginValidator(IUserService userService)
        {
            _userService = userService;
        }
        public async Task ValidateAsync(UserLoginData model, ModelStateDictionary modelState)
        {
            if(string.IsNullOrWhiteSpace(model.Login))
            {
                modelState.AddModelError("Login", "login_cannot_be_empty");
            }
            else
            {
                user = await _userService.GetUserByNameAsync(model.Login);
                
                if(user == null)
                {
                    modelState.AddModelError("Login", "no_such_user");
                }
            }

            if(string.IsNullOrWhiteSpace(model.Password))
            {
                modelState.AddModelError("Password", "password_cannot_be_empty");
            }
            else
            {
                if(user != null)
                {
                    //todo: add password encryption/check service
                    if (model.Password != user.Password)
                    {
                        modelState.AddModelError("Password", "password_incorrect");
                    }
                }
            }
            
        }
    }
}
