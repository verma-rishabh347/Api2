using Microsoft.VisualBasic;
using WebApplication5Self.Data;
using WebApplication5Self.Model.Dto.Otp;

namespace WebApplication5Self.Services.GenerateOTP;

public class OtpService:IOtpService
{
    private readonly DataContext  _context;
    public OtpService(DataContext context)
    {
        _context = context;
        
    }


    public  string GenerateOtp(int id)
    {
        var code= new Random().Next(1000,9999);

        var otp = new OTP
        {
            OtpCode = code,
            UserId = id,
            Time = DateTime.UtcNow,
            IsUsed =  false
           
            
            
        };
        var oldlist = _context.OTPs.Where(x => x.UserId==id && x.IsUsed == false).ToList();
        foreach (var VARIABLE in oldlist)
        {
            VARIABLE.IsUsed = true;
            
        }
        
         _context.OTPs.Add(otp);
         _context.SaveChanges();
        
        return code.ToString();
        
    }

    public bool ValidateOtpService( int Userid,int otp)
    {
    
        var user = _context.OTPs.OrderByDescending(x=>x.Time).FirstOrDefault(x => x.UserId == Userid);

        if (user == null )
        {
            return false;
            
            
        }

        if (user.IsUsed == true)
        {
            return false;
            
        }

        if (user.Time.AddMinutes(10) < DateTime.UtcNow)
        {
            user.IsUsed = true;
            _context.SaveChanges();
            return false;
            
            
        }

        if (user.OtpCode == otp)
        {
            user.IsUsed = true;
            _context.SaveChanges();
            
            return true;
            
        }
        return false;
        
        

        

    }
    
}
