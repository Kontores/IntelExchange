using Microsoft.AspNetCore.Mvc;
using IntelExchange.DataAccess.Interfaces;
using IntelExchange.DataModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace IntelExchange.WebApi.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        public AccountController(ILogger<AccountController> logger, IUserService userService) : base(logger)
        {
            _userService = userService;
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginModel userLoginData)
        {
            var users = await _userService.GetAllUsersAsync();
            var user = users.FirstOrDefault(user => user.Login == userLoginData.Login && user.Password == userLoginData.Password);
            if (user != null)
            {
                await Authenticate(user);
                Log("User " + userLoginData.Login + " logged into the system");
                return Ok();

            }

            return BadRequest();
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