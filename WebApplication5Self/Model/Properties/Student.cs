using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5Self.Model;

public class Student
{

[Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int RollNo { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string FatherName  { get; set; }
    public string MotherName { get; set; }
    public string ContactNumber { get; set; }
    public string Address { get; set; }
    [ForeignKey("Clas")]
    public int ClassId { get; set; }
    public Clas Clas { get; set; }
   
    
    


}