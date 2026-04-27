using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication5Self.Services;
using WebApplication5Self.Services.GenerateToken;

namespace WebApplication5Self.Controller;
[ApiController]
[Route("[controller]")]
public class AuthController: ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController( IAuthService authService)
    {
        _authService = authService;
    }

    
    [HttpPost("Login")]
    public async Task<IActionResult> Get(string email, string password)
    {
        var result = await _authService.Login(email, password);
        return Ok(result);
    }

    [Authorize]
    [HttpPost("Change Password")]
    public async Task<string> ChangePassword(string oldPassword, string newPassword)
    {
        return await _authService.ChangePassword(oldPassword, newPassword);
    }

    

 
    [HttpPost("ForgotPassword")]
    public async Task<string> ForgotPassword(string email)
    {
        return await _authService.ForgotPassword(email);
    }

    [HttpPost("ForgotPasswordConfirm")]

    public async Task<IActionResult> ValidateOtp(string email, int otp, string password)
    {
        
        return Ok(await _authService.ValidateOTP(email, otp, password)) ;
    }
    
    
    
   
    

}