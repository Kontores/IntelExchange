using System.ComponentModel.DataAnnotations;
using IntelExchange.DataModels;
using IntelExchange.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IntelExchange.WebApi.Validation
{
    public class LoginValidator : BasicValidator<UserLoginData>
    {
        private readonly IUserService _userService;
        private User? user;
        public LoginValidator(ModelStateDictionary modelState, IUserService userService): base(modelState)
        {
            _userService = userService;
        }
        public override async Task ValidateAsync(UserLoginData model)
        {
            if(string.IsNullOrWhiteSpace(model.Login))
            {
                _modelState.AddModelError("Login", "login_cannot_be_empty");
            }
            else
            {
                user = await _userService.GetUserByNameAsync(model.Login);
                
                if(user == null)
                {
                    _modelState.AddModelError("Login", "no_such_user");
                }
            }

            if(string.IsNullOrWhiteSpace(model.Password))
            {
                _modelState.AddModelError("Password", "password_cannot_be_empty");
            }
            else
            {
                if(user != null)
                {
                    //todo: add password encryption/check service
                    if (model.Password != user.Password)
                    {
                        _modelState.AddModelError("Password", "password_incorrect");
                    }
                }
            }
            
        }
    }
}
