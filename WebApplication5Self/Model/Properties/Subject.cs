using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5Self.Model;

public class Subject
{
[Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Code { get; set; }
    [ForeignKey("Student")]
    public int StudentId { get; set; }
    public Student Student { get; set; }
    
}