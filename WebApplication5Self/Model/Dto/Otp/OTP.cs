using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5Self.Model.Dto.Otp;

public class OTP
{
    
        [Key]
        public int Id { get; set; }
        public int OtpCode { get; set; }
    
        [ForeignKey("User")]
        public int UserId { get; set; }
        public Users user { get; set; }
    
   
}  