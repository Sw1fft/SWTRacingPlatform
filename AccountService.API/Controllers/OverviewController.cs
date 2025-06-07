using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers
{
    [ApiController]
    public class OverviewController : ControllerBase
    {
        public OverviewController()
        {
            
        }

        [HttpGet("[action]")]
        public IActionResult GetOverviewData()
        {
            return NoContent();
        }

        [HttpGet("[action]")]
        public IActionResult GetStatisticData()
        {
            return NoContent();
        }
    }
}
