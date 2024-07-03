using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using weddingApp.Model;
using weddingApp.Model.DTO_s;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoupleController : ControllerBase
    {
        private readonly ICoupleService _coupleService;
        private readonly IMapper _mapper;
        public CoupleController(ICoupleService coupleService, IMapper mapper)
        {
            _coupleService = coupleService;
            _mapper = mapper;
        }
        [HttpGet("GetAllCouple")]
        public async Task<ActionResult<IEnumerable<Couple>>> GetAllCouple()
        {
            IEnumerable<Couple>? couples = await _coupleService.GetAllCouples();
            if(couples == null || couples.Count() <= 0)
                return BadRequest("Empty table");
            var couplesDTO = _mapper.Map<IEnumerable<CoupleDto>>(couples);
            return Ok(couplesDTO);
        }
        [HttpGet("GetCoupleById")]
        public async Task<ActionResult<Couple>> GetCoupleById(int id)
        { 
            Couple? couple = await _coupleService.GetCouplesById(id);
            if (couple == null)
                return BadRequest("This couple dosn't exist.");

            CoupleDto? coupleDTO = _mapper.Map<CoupleDto>(couple);
            return Ok(coupleDTO);
        }
        [HttpPost("CreateCouple")]
        public async Task<ActionResult> CreateCouple([FromBody] CoupleDto coupleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest($"Invalid couple {coupleDto}");
            Couple? couple = _mapper.Map<Couple>(coupleDto);
            await _coupleService.CreateCouple(couple);
            

        }
    }
}
