using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication5Self.Services.GenerateToken;

namespace WebApplication5Self.Controller;
[ApiController]
[Route("[controller]")]
public class AuthController: ControllerBase
{
    private readonly ITokenService _tokenService;
    public AuthController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    
    [HttpGet("Login")]
    public async Task<IActionResult> Get(string name, string password)
    {
        var result = await _tokenService.Login(name, password);
        return Ok(result);
    }

    [Authorize]
    [HttpPost("Change Password")]
    public async Task<string> ChangePassword(string oldPassword, string newPassword)
    {
        return await _tokenService.ChangePassword(oldPassword, newPassword);
    }
    
    
    
    [Authorize]
    [HttpGet("Auth")]
    public IActionResult GetAuth()
    {
        return Ok("you are authrozise");

    }
    
    [Authorize(Roles="Admin")]
    [HttpGet("Admin")]
    public IActionResult GetAdmin()
    {
        return Ok("you are admin");
    }

    [Authorize(Roles = "User")]
    [HttpGet("User")]
    public IActionResult GetUser()
    {
        return Ok("you are user");
    }
    

}