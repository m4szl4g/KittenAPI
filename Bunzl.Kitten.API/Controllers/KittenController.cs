using System.Threading.Tasks;
using Bunzl.Kitten.API.Authentication;
using Bunzl.Kitten.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bunzl.Kitten.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [BasicAuthorization]
    public class KittenController : ControllerBase
    {
        private readonly IKittenService _kittenService;

        public KittenController(IKittenService kittenService)
        {
            _kittenService = kittenService;
        }

        /// <summary>
        /// Gets a kitten picture which is rotated by 180 degrees.
        /// </summary>
        /// <response code="200">Kitten is visible and rotated by 180 degrees</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return File(await _kittenService.GetAsync(), "image/jpeg");
        }
    }
}
