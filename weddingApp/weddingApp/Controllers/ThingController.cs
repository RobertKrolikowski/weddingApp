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
            IEnumerable<Thing>? things = await _thingService.GetAllThings();
            if (things != null && things.Count() > 0 )
                return Ok(things);
            else
                return BadRequest("Empty table");
        }
        [HttpGet("GetThing")]
        public async Task<ActionResult<Thing>> GetThing(int id)
        { 
            var thing = await _thingService.GetThing(id);
            if (thing != null)
                return Ok(thing);
            else
                return BadRequest("This thing dosn't exist.");
        }

        [HttpPost("CreateThing")]
        public async Task<ActionResult> CreateThing([FromBody]Thing thing)
        {
            if (thing == null)
                return BadRequest("Incorrect thing");
            else
                return Ok(await _thingService.CreateThing(thing));
        }

        //[HttpPost("CreateThing")]
        //public async Task<ActionResult> CreateThing(string name)
        //{
        //    if (string.IsNullOrWhiteSpace(name))
        //        return BadRequest("Incorrect thing");
        //    else
        //        return Ok(await _thingService.CreateThing(new Thing() { Name = name}));
        //} nie wiem jak to zrobić dobrze w jednym 

        [HttpDelete("DeleteThing")]
        public async Task<ActionResult> DeleteThing(int id)
        { 
            var thing = await _thingService.GetThing(id);
            if (thing != null)
                return Ok(await _thingService.DeleteThing(thing));
            else
                return BadRequest("Incorrect id");
        }
    }
}
