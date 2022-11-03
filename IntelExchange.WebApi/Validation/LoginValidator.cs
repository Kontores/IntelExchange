using IntelExchange.WebApi.Models;
using IntelExchange.DataModels;
using IntelExchange.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace IntelExchange.WebApi.Validation
{
    public class LoginValidator : BasicValidator<UserLoginModel>, IAsyncValidator<UserLoginModel>
    {
        private readonly IUserService _userService;
        private User? user;
        public LoginValidator(IActionContextAccessor actionContextAccessor, IUserService userService): base(actionContextAccessor)
        {
            _userService = userService;
        }
        public async Task ValidateAsync(UserLoginModel model)
        {
            if(string.IsNullOrWhiteSpace(model.Login))
            {
                _modelState.AddModelError("login", "validation.login_cannot_be_empty");
            }
            else
            {
                user = await _userService.GetUserByNameAsync(model.Login);
                
                if(user != null)
                {
                    _modelState.AddModelError("login", "validation.user_already_exists");
                }
            }

            if(string.IsNullOrWhiteSpace(model.Password))
            {
                _modelState.AddModelError("password", "validation.password_cannot_be_empty");
            }            
        }
    }
}
