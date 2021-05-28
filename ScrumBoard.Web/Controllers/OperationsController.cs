using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace ScrumBoard.Web.Controllers
{
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly IConfiguration _config;

        public OperationsController(IConfiguration config) {
            _config = config;
        }

        [HttpOptions("reloadconfig")]
        public IActionResult ReloadConfig() {
            try {
                var root = (IConfigurationRoot)_config;
                root.Reload();
                return Ok();
            } catch (Exception) {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
