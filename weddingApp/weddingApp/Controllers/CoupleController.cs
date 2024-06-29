using Microsoft.AspNetCore.Mvc;
using weddingApp.Model.Entities;
using weddingApp.Services;

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
            var couples = _coupleService.GetAllCouples();
            if(couples.Result != null && couples.Result.Count() > 0)
                return Ok(await couples);
            else
                return BadRequest("Empty table");
        }
    }
}
