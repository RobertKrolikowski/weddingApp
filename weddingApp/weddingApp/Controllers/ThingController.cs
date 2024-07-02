using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using weddingApp.Model.DTO_s;
using weddingApp.Model.Entities;
using weddingApp.Services;

namespace weddingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThingController : ControllerBase
    {
        private readonly IThingService _thingService;
        private readonly IMapper _mapper;
        public ThingController(IThingService thingService, IMapper mapper)
        {
            _thingService = thingService;
            _mapper = mapper;
        }
        [HttpGet("GetAllThings")]
        public async Task<ActionResult<IEnumerable<Thing>>> GetAllThings()
        {
            IEnumerable<Thing> things = await _thingService.GetAllThings();
            if (things == null || things.Count() <= 0)
                return BadRequest("Empty table");

            IEnumerable<ThingDto> thingsDto = _mapper.Map<IEnumerable<ThingDto>>(things);
            return Ok(thingsDto);

        }
        [HttpGet("GetThingById")]
        public async Task<ActionResult<Thing>> GetThingById(int id)
        {
            var thing = await _thingService.GetThingById(id);
            if (thing == null)
                return BadRequest("This thing dosn't exist.");

            var thingDto=_mapper.Map<ThingDto>(thing);
            return Ok(thingDto);
        }

        [HttpPost("CreateThing")]
        public async Task<ActionResult> CreateThing([FromBody] ThingDto thingDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Thing thing = _mapper.Map<Thing>(thingDto);
            Thing? createdThing = await _thingService.CreateThing(thing);

            ThingDto? createdThingDto = _mapper.Map<ThingDto>(createdThing);
            return CreatedAtAction("GetThingById", new { id = createdThingDto.Id }, createdThingDto);
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
            var thing = await _thingService.GetThingById(id);
            if (thing != null)
                return Ok(await _thingService.DeleteThing(thing));
            else
                return BadRequest("Incorrect id");
        }
    }
}
