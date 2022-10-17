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

        protected void Log(string message, LogLevel logLevel = LogLevel.Information)
        {
            switch (logLevel)
            {
                case LogLevel.Debug:
                    _logger.LogDebug(message);
                    break;
                case LogLevel.Warning:
                    _logger.LogWarning(message);
                    break;
                case LogLevel.Error:
                    _logger.LogError(message);
                    break;
                case LogLevel.Critical:
                    _logger.LogCritical(message);
                    break;
                default:
                    _logger.LogInformation(message);
                    break;
            }
        }
    }
}
