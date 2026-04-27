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
    
    public TokenService(IConfiguration configuration,DataContext dataContext,IHttpContextAccessor httpContextAccessor)
    {
        _configuration = configuration;
    }
    

   

    public string  GenerateToken(int userId,string role)
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

   


   
    
    

    
}