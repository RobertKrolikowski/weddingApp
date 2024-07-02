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
            IEnumerable<Service>? services = await _serviceService.GetAllServices();
            if (services == null || services.Count() <= 0)
                return BadRequest("Empty table");
            else 
                return Ok(services);
        }
    }
}
