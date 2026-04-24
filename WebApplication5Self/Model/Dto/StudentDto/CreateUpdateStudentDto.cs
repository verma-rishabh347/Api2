namespace WebApplication5Self.Model.Dto.StudentDto;

public class CreateUpdateStudentDto
{
    
    public string Name { get; set; }
    public int RollNo { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string FatherName  { get; set; }
    public string MotherName { get; set; }
    public string ContactNumber { get; set; }
    public string Address { get; set; }
   
    public int ClassId { get; set; }
  

    
}