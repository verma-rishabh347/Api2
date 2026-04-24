using Microsoft.EntityFrameworkCore;
using WebApplication5Self.Model;
using WebApplication5Self.Model.Dto.Otp;

namespace WebApplication5Self.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<School> Schools { get; set; }
    public DbSet<Clas>  Classes { get; set; }
    public DbSet<Student> Students { get; set; }
    
    public DbSet<Users> Users { get; set; }
    
    public DbSet<OTP> OTPs { get; set; }
    
    
}