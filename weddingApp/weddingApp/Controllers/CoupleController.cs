using Microsoft.AspNetCore.Mvc;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoupleController : ControllerBase
    {
        private readonly ICoupleService _coupleService;
        public CoupleController(ICoupleService coupleService)
        {
            _coupleService = coupleService;
        }
        [HttpGet("GetAllCouple")]
        public async Task<ActionResult<IEnumerable<Couple>>> GetAllCouple()
        {
            IEnumerable<Couple>? couples = await _coupleService.GetAllCouples();
            if(couples == null || couples.Count() <= 0)
                return BadRequest("Empty table");
            else
                return Ok(couples);
        }
    }
}
