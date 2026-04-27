namespace WebApplication5Self.Services;

public interface IAuthService
{

     Task<string> Login(string email, string password);
     Task<string> ChangePassword(string oldPassword, string newPassword);
     

     Task<string> ForgotPassword(string userName);

     Task<string> ValidateOTP(string email, int otp, string password);

}