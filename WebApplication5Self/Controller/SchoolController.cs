using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication5Self.Model.Dto.SchoolDto;
using WebApplication5Self.Repository;

namespace WebApplication5Self.Controller;
[ApiController]
[Route("[controller]")]
public class SchoolController:ControllerBase
{
    
    private readonly ISchoolRepository _schoolRepository;
    public SchoolController(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }
    
    
    
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_schoolRepository.GetSchool());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_schoolRepository.GetSchool(id));
    }

    [HttpPost]
    public IActionResult Post(CreateUpdateSchoolDto  classDto)
    {
        return Ok(_schoolRepository.CreateSchool(classDto));

    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, CreateUpdateSchoolDto schoolDto)
    {
        return Ok(_schoolRepository.UpdateSchool(id,schoolDto));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(_schoolRepository.DeleteSchool(id));
    }
   
    
}