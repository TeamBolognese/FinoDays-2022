using CreditPipeline.API.Contracts.User;
using CreditPipeline.API.Repositories;
using CreditPipeline.Model;
using Microsoft.AspNetCore.Mvc;
using BC = BCrypt.Net.BCrypt;

namespace CreditPipeline.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }
    
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(_userRepository.GetAllUsers());
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user is null) return NotFound();
        return Ok(user);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] AddUserDto addUserDto)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = addUserDto.Name,
            Login = addUserDto.Login,
            Password = BC.HashPassword(addUserDto.Password)
        };
        
        await _userRepository.Add(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }
}
