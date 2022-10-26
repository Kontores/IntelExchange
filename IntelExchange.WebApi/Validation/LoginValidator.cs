using IntelExchange.DataModels;
using IntelExchange.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IntelExchange.WebApi.Validation
{
    public class LoginValidator : BasicValidator<UserLoginModel>
    {
        private readonly IUserService _userService;
        private User? user;
        public LoginValidator(IActionContextAccessor actionContextAccessor, IUserService userService): base(actionContextAccessor)
        {
            _userService = userService;
        }
        public override async Task ValidateAsync(UserLoginModel model)
        {
            if(string.IsNullOrWhiteSpace(model.Login))
            {
                _modelState.AddModelError("login", "validation.login_cannot_be_empty");
            }
            else
            {
                user = await _userService.GetUserByNameAsync(model.Login);
                
                if(user == null)
                {
                    _modelState.AddModelError("login", "validation.no_such_user");
                }
            }

            if(string.IsNullOrWhiteSpace(model.Password))
            {
                _modelState.AddModelError("password", "validation.password_cannot_be_empty");
            }
            else
            {
                if(user != null)
                {
                    //todo: add password encryption/check service
                    if (model.Password != user.Password)
                    {
                        _modelState.AddModelError("password", "validation.password_incorrect");
                    }
                }
            }
            
        }

        public override void Validate(UserLoginModel model)
        {
            throw new NotImplementedException();
        }
    }
}
