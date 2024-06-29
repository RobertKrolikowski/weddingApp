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
            Task<IEnumerable<Guest>>? guests = _guestService.GetAllGuests();
            if (guests.Result != null && guests.Result.Count() > 0)
                return Ok(await guests);
            else
                return BadRequest("Empty table");
        }
    }
}
