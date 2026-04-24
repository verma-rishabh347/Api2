using System.ComponentModel.DataAnnotations;

namespace WebApplication5Self.Model;

public class School
{
    [Key]
    public  int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PrincipalName { get; set; }
    public string Email { get; set; }
}