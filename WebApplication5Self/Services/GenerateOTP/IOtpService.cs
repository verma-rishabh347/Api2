using WebApplication5Self.Model.Dto.Otp;

namespace WebApplication5Self.Services.GenerateOTP;

public interface IOtpService
{

     public string GenerateOtp(int id);
     
     public bool ValidateOtpService( int id,int otp);

  



}