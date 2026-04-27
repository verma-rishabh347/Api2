using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebApplication5Self.Data;
using WebApplication5Self.Model;
using WebApplication5Self.Model.Dto.Otp;
using WebApplication5Self.Services.GenerateOTP;
using WebApplication5Self.Services.GenerateToken;
using WebApplication5Self.Services.MailServices;


namespace WebApplication5Self.Services;

public class AuthService:IAuthService
{
    private readonly DataContext _dbcontext;
    private readonly ITokenService _tokenService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IOtpService _otpService;
    private readonly IMailServicees _mailService;

    public AuthService(IMailServicees mailService,DataContext dbcontext,IOtpService otpService , ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
    {
        _dbcontext = dbcontext;
        _tokenService = tokenService;
        _httpContextAccessor = httpContextAccessor;
        _otpService = otpService;
        _mailService = mailService;
        
        
    }
    
    
    
    public async Task<string> Login(string email, string password)
    {
        var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        if (user == null)
        {
            return "No data Found";

        }

        var token = _tokenService.GenerateToken(user.Id,"User");
        return token;
    }
    
    
    
    
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
    
    
    



    public async Task<string> ForgotPassword(string email)
    {
        var user=await _dbcontext.Users.FirstOrDefaultAsync(x=>x.Email==email);

        if (user == null)
        {
            return "User not found";
        }

       

        var otp =  _otpService.GenerateOtp(user.Id);
        var mailmsg = new MailMessage { To = email , Body = otp , Subject = "Verification otp"  };
        _mailService.SendMail(mailmsg);

        return "Success";





    }

    public async Task<string> ValidateOTP(string email,int otp , string password)
    {
        var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Email == email);
        if (user == null)
        {
            return "User not found";
        }

       

        bool OTPSituation =  _otpService.ValidateOtpService(user.Id, otp);

        if (OTPSituation)
        {
            user.Password = password;
            _dbcontext.Users.Update(user);
            await _dbcontext.SaveChangesAsync();
            return "Done";
             
        }

        return "Something wrong";











    }
}