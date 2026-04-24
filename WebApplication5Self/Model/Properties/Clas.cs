using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5Self.Model;

public class Clas
{
    [Key]
    public int ClassId { get; set; }

    public string Section { get; set; }
    [ForeignKey("School")]
    public int SchoolId { get; set; }
    
    public School School { get; set; }

  
}