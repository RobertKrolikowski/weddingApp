using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using weddingApp.Model.DTO_s;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeddingEventController : ControllerBase
    {
        private readonly IWeddingEventService _weddingEventService;
        private readonly IGiftService _giftService;
        private readonly IMapper _mapper;
        public WeddingEventController(IWeddingEventService weddingEventService, IGiftService giftService, IMapper mapper)
        {
            _weddingEventService = weddingEventService;
            _giftService = giftService;
            _mapper = mapper;
        }

        [HttpGet("GetAllWeddingEvents")]
        public async Task<ActionResult<IEnumerable<WeddingEvent>>> GetAllWeddingEvents()
        {
            IEnumerable<WeddingEvent>? weddingEvents = await _weddingEventService.GetAllWeddingEvents();
            if(weddingEvents == null && weddingEvents.Count() <= 0)
                return BadRequest("Empty table");
            else 
                return Ok(weddingEvents);
        }

        [HttpGet("GetWeddingEventById")]
        public async Task<ActionResult<WeddingEvent>> GetWeddingEventById(int id)
        {
            WeddingEvent? weddingEvent = await _weddingEventService.GetWeddingEventById(id);
            if(weddingEvent == null)
                return NotFound();
            
            WeddingEvent? weddingEventDto = _mapper.Map<WeddingEvent>(weddingEvent);
            return Ok(weddingEventDto);
        }
        [HttpPost("CreateWeddinEvent")]
        public async Task<ActionResult> CreateWeddingEvent([FromBody] WeddingEvent weddinEventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var weddingEvent = _mapper.Map<WeddingEvent>(weddinEventDto);
            var createdWeddingEvent = await _weddingEventService.CreateWeddingEvent(weddingEvent);
            var createdWeddingEventDto = _mapper.Map<WeddingEventDto>(createdWeddingEvent);

            return CreatedAtAction("GetWeddingEventById", new { id = createdWeddingEventDto.Id }, createdWeddingEventDto);
        }
        [HttpPut("UpdateWeddingEvent/{id}")]
        public async Task<ActionResult> UpdateWeddingEvent(int id, [FromBody] WeddingEventDto weddingEventDto)
        { 
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            WeddingEvent? existingWeddingEvent = await _weddingEventService.GetWeddingEventById(id);
            if(existingWeddingEvent == null)
                return NotFound();

            WeddingEvent? weddingEventToUpdate = _mapper.Map<WeddingEvent>(weddingEventDto);
            await _weddingEventService.UpdateWeddingEvent(weddingEventToUpdate);
            return Ok(_mapper.Map<WeddingEventDto>(weddingEventToUpdate));
        }
        [HttpPut("AddGift")]
        public async Task<ActionResult> AddGift(int idWeddingEvent, int idGift)
        {
            WeddingEvent? existingWeddingEvent = await _weddingEventService.GetWeddingEventById(idWeddingEvent);
            if (existingWeddingEvent == null)
                return NotFound();

            Gift? existingGift = await _giftService.GetGiftById(idGift);
            if (existingGift == null)
                return NotFound();

            var weddingEventUpdated = await _weddingEventService.AddGift(idWeddingEvent,idGift);
            return Ok(_mapper.Map<WeddingEventDto>(weddingEventUpdated));
        }
        [HttpDelete("DeleteWeddingEvent")]
        public async Task<ActionResult> DeleteWeddingEvent(int id)
        { 
            var weddingEvent = await _weddingEventService.GetWeddingEventById(id);
            if (weddingEvent == null)
                return BadRequest("Incorrect Id");
            await _weddingEventService.DeleteWeddingEvent(weddingEvent);
            return Ok(weddingEvent);
        }

    }
}
