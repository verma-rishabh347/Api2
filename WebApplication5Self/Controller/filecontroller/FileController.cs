using Microsoft.AspNetCore.Mvc;
using WebApplication5Self.Model;

namespace WebApplication5Self.Controller.filecontroller;
[ApiController]
[Route("[controller]")]
public class FileController:ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Post(FileModel files)
    {
        if (files ==null && files.File==null && files.File.Length==0)
        {
            return BadRequest("Something is wrong");
            
        }
        
        var rootpath = Directory.GetCurrentDirectory();
        var folderpath = Path.Combine(rootpath,"wwwroot/Doc");
        var filepath =Path.Combine(folderpath,files.File.FileName);

        var stream = new FileStream(filepath, FileMode.Create);
        await files.File.CopyToAsync(stream);
        stream.Close();
        
        return Ok("Upload Success");


    }
    
    
}