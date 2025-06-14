using AccountService.Domain.Abstractions.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers
{
    [ApiController]
    public class HeaderContentController : ControllerBase
    {
        #region private
        private readonly IHeaderService _headerService;
        #endregion

        public HeaderContentController(IHeaderService headerService)
        {
            _headerService = headerService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPublicHeaderData()
        {
            var result = await _headerService.GetPublicHeaderData();

            return Ok(result);
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPrivateHeaderData()
        {
            var result = await _headerService.GetPrivateHeaderData();

            return Ok(result);
        }

    }
}
