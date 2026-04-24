using Microsoft.AspNetCore.Mvc;
using WebApplication5Self.Model.Dto.StudentDto;
using WebApplication5Self.Model.Dto.SubjectDto;
using WebApplication5Self.Repository;

namespace WebApplication5Self.Controller;
[ApiController]
[Route("[controller]")]

public class StudentController:ControllerBase
{
    
    private readonly IStudentRepository _studentRepository;
    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    
    
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_studentRepository.GetStudent());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_studentRepository.GetStudent(id));
    }

    [HttpPost]
    public IActionResult Post(CreateUpdateStudentDto  studentDto)
    {
        return Ok(_studentRepository.CreateStudent(studentDto));

    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, CreateUpdateStudentDto studentDto)
    {
        return Ok(_studentRepository.UpdateStudent(id,studentDto));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(_studentRepository.DeleteStudent(id));
    }
   
    
}