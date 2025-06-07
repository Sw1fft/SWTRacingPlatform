using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers
{
    [ApiController]
    public class HeaderContentController : ControllerBase
    {
        public HeaderContentController()
        {
            
        }

        [HttpGet]
        public IActionResult GetHeaderData()
        {
            return NoContent();
        }
    }
}
