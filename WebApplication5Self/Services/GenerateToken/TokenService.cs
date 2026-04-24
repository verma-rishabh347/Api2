using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication5Self.Data;
using WebApplication5Self.Model;
using WebApplication5Self.Model.Dto.Otp;

namespace WebApplication5Self.Services.GenerateToken;

public class TokenService:ITokenService
{
    
    private readonly IConfiguration _configuration;
    private readonly DataContext _dbcontext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public TokenService(IConfiguration configuration,DataContext dataContext,IHttpContextAccessor httpContextAccessor)
    {
        _configuration = configuration;
        _dbcontext = dataContext;
        _httpContextAccessor = httpContextAccessor;
    }
    

   

    public string GenerateToken(int userId,string role)
    {
        
        
        var key = _configuration["JWTSettings:SecretKey"];
        var issuer = _configuration["JWTSettings:Issuer"];
        var audience = _configuration["JWTSettings:Audience"];
        var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        var claims = new Claim[]
        {
            new Claim("role", role),
            new Claim("UserId", userId.ToString())
        };
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials:new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256));
        
        return new JwtSecurityTokenHandler().WriteToken(token);
        

    }

    public async Task<string> Login(string name, string password)
    {
        var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Username == name && x.Password == password);
        if (user == null)
        {
            return "No data Found";

        }

        var token = GenerateToken(user.Id,"User");
        return token;
    }

    [Authorize]
    [HttpPost("change-password")]
    public async Task<string> ChangePassword(string oldPassword, string newPassword)
    {
        var claimUserId = _httpContextAccessor.HttpContext.User.FindFirst("UserId");
        var userid = Convert.ToInt32(claimUserId.Value);
        
        var user = await _dbcontext.Users.FirstOrDefaultAsync(x=>x.Id == userid&&x.Password == oldPassword);
        if (user == null)
        {
            return "User not found";
        }
        
        user.Password = newPassword;
        await _dbcontext.SaveChangesAsync();
        return "Success";
        
    }

    [Authorize]
    [HttpPost("reset password")]
    public async Task<string> ResetPassword(string newPassword)
    {
        var claimuserid = _httpContextAccessor.HttpContext.User.FindFirst("UserId");
        var userid = Convert.ToInt32(claimuserid.Value);
        
        var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Id == userid);
        if (user == null)
        {
            return "User not found";
        }
        user.Password = newPassword;
        _dbcontext.Users.Update(user);
        await _dbcontext.SaveChangesAsync();
        return "Success";
        
    }


    [HttpPost("forgot")]
    public async Task<string> ForgotPassword(string userName)
    {
        var user=await _dbcontext.Users.FirstOrDefaultAsync(x=>x.Username==userName);

        if (user == null)
        {
            return "User not found";
        }

        var code = new Random().Next(1000, 9999);
        var otp = new OTP()
        {
            OtpCode = code,
            UserId = user.Id
        };
        await _dbcontext.OTPs.AddAsync(otp);
        await _dbcontext.SaveChangesAsync();
        
        return code.ToString();






    }
    
    

    
}