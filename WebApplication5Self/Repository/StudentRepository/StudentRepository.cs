using WebApplication5Self.Data;
using WebApplication5Self.Model;
using WebApplication5Self.Model.Dto.StudentDto;
using System.Linq;

namespace WebApplication5Self.Repository;

public class StudentRepository:IStudentRepository
{
    private readonly DataContext _context;
    public StudentRepository(DataContext context)
    {
        _context = context;
    }


    public List<GetStudentDto> GetStudent()
    {
        return _context.Students.Select(x => new GetStudentDto
        {
            Id = x.Id, Address = x.Address, Name = x.Name, RollNo = x.RollNo, ContactNumber = x.ContactNumber,
            ClassId = x.ClassId
        }).ToList();
    }

    public GetStudentDto GetStudent(int id)
    {
       
        return _context.Students.Where(x => x.Id == id).Select(x => new GetStudentDto { Id = x.Id, Name = x.Name, RollNo = x.RollNo,ContactNumber = x.ContactNumber,Address = x.Address,ClassId = x.ClassId }).FirstOrDefault();

        
            
            
    }
        

    public string CreateStudent(CreateUpdateStudentDto studentDto)
    {
        if (_context.Students.Any(x=>x.RollNo==studentDto.RollNo))
        {
            return "student already exists";
            
        }
        else
        {
            var student = new Student
            {
                RollNo = studentDto.RollNo,
                Address = studentDto.Address,
                Name = studentDto.Name,
              
                Age = studentDto.Age,
                Gender = studentDto.Gender,
                ClassId = studentDto.ClassId,
                MotherName = studentDto.MotherName,
                FatherName = studentDto.FatherName,
                ContactNumber = studentDto.ContactNumber
            };
            _context.Students.Add(student);
            _context.SaveChanges();
            return $"student is added";
        }
    }

    public string UpdateStudent(int id,CreateUpdateStudentDto studentDto)
    {
        var student = _context.Students.FirstOrDefault(x => x.Id == id);
        if (student != null)
        {
            if (_context.Students.Any(x => x.Id != id && x.RollNo == studentDto.RollNo))
            {
                return "rollno is already taken";
            }
            else
            {
                student.Address = studentDto.Address;
                student.Name = studentDto.Name;
                student.Age = studentDto.Age;
                student.Gender = studentDto.Gender;
                student.RollNo = studentDto.RollNo;
                student.ClassId = studentDto.ClassId;
                student.FatherName = studentDto.FatherName;
                student.MotherName = studentDto.MotherName;
                student.ContactNumber = studentDto.ContactNumber;
                _context.SaveChanges();
                return $"student is updated";

                
            }
            
        }
        else
        {
            {
                return "rollno is no record found";
            }
        }
    }

    public string DeleteStudent(int id)
    {
        var student = _context.Students.FirstOrDefault(x=>x.Id==id);
        if (student!=null)
        {
            _context.Remove(student);
            _context.SaveChanges();
            return $"student is deleted";
            
        }
        else
        {
            return "no record found";
        }
    }
}