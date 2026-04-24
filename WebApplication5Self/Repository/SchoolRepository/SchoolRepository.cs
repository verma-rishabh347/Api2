using Microsoft.EntityFrameworkCore;
using WebApplication5Self.Data;
using WebApplication5Self.Model;
using WebApplication5Self.Data;
using WebApplication5Self.Model.Dto.SchoolDto;

namespace WebApplication5Self.Repository;

public class SchoolRepository:ISchoolRepository
{
    private readonly DataContext _context;
    public  SchoolRepository(DataContext context)
    {
        _context = context;
        
        
    }

    public async Task<List<GetSchoolDto>> GetSchool()
    {
        return await _context.Schools.Select(x=>new GetSchoolDto{Id =  x.Id, Name = x.Name ,Address = x.Address}).ToListAsync();
    }

    public async Task<GetSchoolDto?> GetSchool(int id)
    {
        return await _context.Schools
            .Where(x => x.Id == id)
            .Select(x => new GetSchoolDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address
            })
            .FirstOrDefaultAsync();
    }

    public async Task<string> CreateSchool(CreateUpdateSchoolDto schoolDto)
    {
        if ( await _context.Schools.AnyAsync(x => x.Name == schoolDto.Name || x.Email == schoolDto.Email))
        {
            return $"School {schoolDto.Name} or Email {schoolDto.Email} already exists";
        }

        var school = new School
        {
            PrincipalName =  schoolDto.PrincipalName,
            Name = schoolDto.Name,
            Email = schoolDto.Email,
            Address = schoolDto.Address
        };

         _context.Schools.Add(school);
        await _context.SaveChangesAsync();

        return $"School {school.Name} added";
    }

    public async Task<string> UpdateSchool(int id, CreateUpdateSchoolDto schoolDto)
    {
        var school =  _context.Schools.FirstOrDefault(x => x.Id == id);

        if (school == null)
        {
            return "School not found";
        }

        if (_context.Schools.Any(x => x.Id != id &&
                                      (x.Name == schoolDto.Name || x.Email == schoolDto.Email)))
        {
            return "School name or email already exists";
        }

        school.Name = schoolDto.Name;
        school.Email = schoolDto.Email;
        school.Address = schoolDto.Address;

        _context.SaveChanges();

        return $"School {school.Name} updated";
    }

    public async Task<string> DeleteSchool(int id)
    {
        var school = _context.Schools.FirstOrDefault(x => x.Id == id);

        if (school == null)
        {
            return "School not found";
        }

        _context.Schools.Remove(school);
        _context.SaveChanges();

        return $"School {school.Name} deleted";
    }
}