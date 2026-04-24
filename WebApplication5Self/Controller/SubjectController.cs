using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication5Self.Model.Dto.SubjectDto;
using WebApplication5Self.Repository;

namespace WebApplication5Self.Controller;
[ApiController]
[Route("[controller]")]

public class SubjectController:ControllerBase
{
    
    private readonly ISubjectRepository _subjectRepository;
    public SubjectController(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }
    
    
    
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_subjectRepository.GetSubject());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_subjectRepository.GetSubject(id));
    }

    [HttpPost]
    public IActionResult Post(CreateUpdateSubjectDto  subjectDto)
    {
        return Ok(_subjectRepository.CreateSubject(subjectDto));

    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, CreateUpdateSubjectDto subjectDto)
    {
        return Ok(_subjectRepository.UpdateSubject(id,subjectDto));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(_subjectRepository.DeleteSubject(id));
    }
   
    
}