using Microsoft.AspNetCore.Mvc;

namespace WebApplication5Self.Services.GenerateToken;

public interface ITokenService
{
    public string  GenerateToken(int userId,string role);
    Task<string> Login(string username, string password);
    Task<string> ChangePassword(string oldPassword, string newPassword);

    Task<string> ResetPassword(string newPassword);

    Task<string> ForgotPassword(string userName);


}