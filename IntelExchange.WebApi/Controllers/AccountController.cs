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
        public async Task<IActionResult> Login(UserLoginData userLoginData)
        {
            var users = _userService.GetAllUsers();
            var user = users.FirstOrDefault(user => user.Login == userLoginData.Login && user.Password == userLoginData.Password);
            if (user != null)
            {
                await AuthenticateAsync(userLoginData.Login);
                Log("User " + userLoginData.Login + " logged into the system");
                return Ok();

            }

            return new BadRequestResult();
        }

        [Route("getuserlogin")]
        [Authorize]
        public IActionResult GetUserLogin()
        {
            return Content(User.Identity.Name);
        }

        private async Task AuthenticateAsync(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}