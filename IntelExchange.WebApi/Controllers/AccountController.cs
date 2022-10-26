using Microsoft.AspNetCore.Mvc;
using IntelExchange.DataAccess.Interfaces;
using IntelExchange.DataModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using IntelExchange.WebApi.Validation;

namespace IntelExchange.WebApi.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IValidator<UserLoginData> _userValidator;
        public AccountController(ILogger<AccountController> logger, IUserService userService, IValidator<UserLoginData> userValidator) : base(logger)
        {
            _userService = userService;
            _userValidator = userValidator;
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginData userLoginData)
        {
            await _userValidator.ValidateAsync(userLoginData);

            if(ModelState.IsValid)
            {
                var user = await _userService.GetUserByNameAsync(userLoginData.Login);
                await Authenticate(user);
                Log("User " + userLoginData.Login + " logged into the system");
                return Ok();
            }

            return BadRequest(new ValidationErrorResult(ModelState));
        }

        [Route("logout")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync();
        }

        [Route("checkadminpermission")]
        [Authorize("AdminPermission")]
        public IActionResult CheckAdminPermission()
        {
            return Content("User has admin permission");
        }

        [Route("getloggeduser")]
        [Authorize]
        public async Task<User> GetLoggedUser()
        {
            var userTask = _userService.GetUserByNameAsync(User.Identity.Name);
            var user = await userTask;
            return user;
        }

        [Route("checkisusernamefree")]
        private async Task<bool> CheckIsUserNameFree(string userName)
        {
            var user = (await _userService.GetAllUsersAsync()).FirstOrDefault(u => u.Login == userName);
            return user == null;
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
            };
            claims.AddRange(user.Roles.Select(role => new Claim("Permission", role.ToString())));

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}