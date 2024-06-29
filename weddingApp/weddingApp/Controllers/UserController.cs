using Microsoft.AspNetCore.Mvc;
using weddingApp.Model.Entities;
using weddingApp.Services;

namespace weddingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            if (users.Result != null && users.Result.Count() > 0)
                return Ok(await users);
            else
                return BadRequest("Empty table");
        }
    }
}
