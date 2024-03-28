using Microsoft.AspNetCore.Mvc;

namespace ventasPymes.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> logger;

        public StatusController(ILogger<StatusController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetStatus()
        {
            return Ok(true);
        }
    }
}
