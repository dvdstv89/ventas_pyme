using Microsoft.AspNetCore.Mvc;

namespace ventasPymes.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityTokenController : ControllerBase
    {
        private readonly ILogger<StatusController> logger;

        public SecurityTokenController(ILogger<StatusController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult UpdateSecurityTokenFunctionalitiesByTokenSelected()
        {
            return Ok(true);
        }
    }
}
