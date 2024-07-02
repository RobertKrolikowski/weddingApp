using Microsoft.AspNetCore.Mvc;
using weddingApp.Model.Entities;
using weddingApp.Services;

namespace weddingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeddingEventController : ControllerBase
    {
        private readonly IWeddingEventService _weddingEventService;
        public WeddingEventController(IWeddingEventService weddingEventService)
        {
            _weddingEventService = weddingEventService;
        }

        [HttpGet("GetAllWeddingEvents")]
        public async Task<ActionResult<IEnumerable<WeddingEvent>>> GetAllWeddingEvents()
        {
            IEnumerable<WeddingEvent>? weddingEvents = await _weddingEventService.GetAllWeddingEvents();
            if(weddingEvents != null && weddingEvents.Count() > 0)
                return Ok( weddingEvents);
            else 
                return BadRequest("Empty table");
        }
    }
}
