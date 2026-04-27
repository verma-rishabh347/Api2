using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5Self.Model.Dto.Otp;

public class OTP
{
    
        [Key]
        public int Id { get; set; }
        public int OtpCode { get; set; }
        
        public DateTime Time { get; set; }
        
        
        
        public bool IsUsed { get; set; }
    
        [ForeignKey("user")]
        public int UserId { get; set; }
        public Users user { get; set; }
    
   
}  