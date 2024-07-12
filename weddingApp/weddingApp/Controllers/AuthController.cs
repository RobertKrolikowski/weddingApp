using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.Conventions;
using weddingApp.Model.DTO_s;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;
using weddingApp.Services.Security;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public AuthController(IJwtService jwtService, IUserService userService,IMapper mapper)
    {
        _jwtService = jwtService;
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserDto userDto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        User? user = await _userService.Authenticate(userDto.Login, userDto.Password);

        if (user == null)
            return Unauthorized();

        string? token = _jwtService.GenerateToken(user);
        UserDto? loginDto = _mapper.Map<UserDto>(user);

        return Ok(new { Token = token, User = loginDto });
    }
}
