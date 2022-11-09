using CreditPipeline.API.Contracts;
using CreditPipeline.API.Contracts.Auth;
using CreditPipeline.API.Repositories;
using CreditPipeline.API.Services;
using Microsoft.AspNetCore.Mvc;
using BC = BCrypt.Net.BCrypt;

namespace CreditPipeline.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private IUserRepository _userRepository;
    private JwtService _jwtService;
    
    public AuthController(IUserRepository userRepository, JwtService jwtService)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthDto authDto)
    {
        var user = await _userRepository.GetUserByLoginAsync(authDto.Login);
        if (user is null) return NotFound();
        
        if (!BC.Verify(authDto.Password, user.Password)) return Unauthorized();
        
        var minutesValid = TimeSpan.FromDays(30).TotalMinutes;
        var token = _jwtService.CreateJwt(user, Convert.ToInt32(minutesValid));
        return Ok(token);
    }
}
