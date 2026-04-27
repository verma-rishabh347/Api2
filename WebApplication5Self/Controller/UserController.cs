using Microsoft.AspNetCore.Mvc;
using WebApplication5Self.Data;
using WebApplication5Self.Model;
using WebApplication5Self.Model.Dto.User;

namespace WebApplication5Self.Controller;
[ApiController]
[Route("/user/[controller]")]
public class UserController:ControllerBase
{
    private readonly DataContext _context;
    public UserController(DataContext context)
    {
        _context = context;
    }
    
    [HttpPost] 
    public async Task<ActionResult> Post( PostUserDto newuser)
    {
        Users users = new Users{Username = newuser.Username, Password = newuser.Password, Email = newuser.Email};
        
        await _context.Users.AddAsync(users);
        await _context.SaveChangesAsync();
        
        return Ok();
    }

    [HttpGet]
    public List<GetUserDto> Get()
    {
        return _context.Users.Select(x=>new GetUserDto{Id = x.Id,Username = x.Username,Password = x.Password,Email = x.Email}).ToList();
        
    }
}