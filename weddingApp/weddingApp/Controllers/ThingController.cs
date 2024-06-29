using Microsoft.AspNetCore.Mvc;
using weddingApp.Model.Entities;
using weddingApp.Services;

namespace weddingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThingController : ControllerBase
    {
        private readonly IThingService _thingService;
        public ThingController(IThingService thingService)
        {
            _thingService = thingService;
        }
        [HttpGet("GetAllThings")]
        public async Task<ActionResult<IEnumerable<Thing>>> GetAllThings()
        {
            Task<IEnumerable<Thing>>? things = _thingService.GetAllThings();
            if (things.Result != null && things.Result.Count() > 0 )
                return Ok(await things);
            else
                return BadRequest("Empty table");
        }
        //[HttpPost("CreateThing")]
        //public async Task<ActionResult> CreateThing(Thing thing)
        //{
        //    if (thing == null)
        //        return BadRequest("Incorrect thing");
        //    else
        //        return Ok(await _thingService.CreateThing(thing));
        //}
    }
}
