using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication5Self.Model.Dto.ClasDto;
using WebApplication5Self.Repository;

namespace WebApplication5Self.Controller;
[ApiController]
[Route("[controller]")]
public class ClasController: ControllerBase
{
    private readonly IClasRepository _clasRepository;
    public ClasController(IClasRepository clasRepository)
    {
        _clasRepository = clasRepository;
    }
    
    
    
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_clasRepository.GetClas());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_clasRepository.GetClas(id));
    }

    [HttpPost]
    public IActionResult Post(CreateUpdateClasDto  classDto)
    {
        return Ok(_clasRepository.CreateClas(classDto));

    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, CreateUpdateClasDto classDto)
    {
        return Ok(_clasRepository.UpdateClas(id,classDto));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(_clasRepository.DeleteClas(id));
    }
   
    
}