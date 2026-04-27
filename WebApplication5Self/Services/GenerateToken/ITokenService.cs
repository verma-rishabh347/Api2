using Microsoft.AspNetCore.Mvc;

namespace WebApplication5Self.Services.GenerateToken;

public interface ITokenService
{
    public string  GenerateToken(int userId,string role);
   


}