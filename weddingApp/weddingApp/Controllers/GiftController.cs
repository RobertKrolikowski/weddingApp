using Microsoft.AspNetCore.Mvc;
using weddingApp.Model.Entities;
using weddingApp.Services;

namespace weddingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _giftService;
        public GiftController(IGiftService giftService)
        {
            _giftService = giftService;
        }
        [HttpGet("GetAllGifts")]
        public async Task<ActionResult<IEnumerable<Gift>>> GetAllGifts()
        {
            IEnumerable<Gift>? gifts = await _giftService.GetAllGifts();
            if (gifts != null && gifts.Count() > 0)
                return Ok( gifts);
            else
                return BadRequest("Empty table");
        }
    }
}
