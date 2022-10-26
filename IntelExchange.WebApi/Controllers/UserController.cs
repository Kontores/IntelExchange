using Microsoft.AspNetCore.Mvc;
using IntelExchange.DataAccess.Interfaces;
using IntelExchange.DataModels;

namespace IntelExchange.WebApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService) : base(logger)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("getallusers")]
        public async Task <IEnumerable<User>> GetAllUsers()
        {
           return await _userService.GetAllUsersAsync();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(User user)
        {
            if(ModelState.IsValid)
            {
                await _userService.CreateUserAsync(user);
                return Ok();
            }
            return BadRequest();
        }
    }
}