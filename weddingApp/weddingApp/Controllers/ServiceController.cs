using Microsoft.AspNetCore.Mvc;
using weddingApp.Model.Entities;
using weddingApp.Services;

namespace weddingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpGet("GetAllServices")]
        public async Task<ActionResult<IEnumerable<Service>>> GetAllService()
        {
            var services = _serviceService.GetAllServices();
            if (services.Result != null && services.Result.Count() > 0)
                return Ok(await services);
            else 
                return BadRequest("Empty table");
        }
    }
}
