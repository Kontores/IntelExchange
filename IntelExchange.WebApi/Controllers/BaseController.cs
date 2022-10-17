using Microsoft.AspNetCore.Mvc;

namespace IntelExchange.WebApi.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        protected void Log(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
