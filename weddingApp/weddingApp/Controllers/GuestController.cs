using Microsoft.AspNetCore.Mvc;
using weddingApp.Model.Entities;
using weddingApp.Services;

namespace weddingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;
        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }
        [HttpGet("GetAllGuests")]
        public async Task<ActionResult<IEnumerable<Guest>>> GetAllGuests()
        {
            IEnumerable<Guest>? guests = await _guestService.GetAllGuests();
            if (guests == null || guests.Count() <= 0)
                return BadRequest("Empty table");
            else
                return Ok(guests);
        }
    }
}
