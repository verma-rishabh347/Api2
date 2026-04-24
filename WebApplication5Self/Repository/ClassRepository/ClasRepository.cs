using WebApplication5Self.Data;
using WebApplication5Self.Model;
using WebApplication5Self.Model.Dto.ClasDto;

namespace WebApplication5Self.Repository;

public class ClasRepository:IClasRepository
{
    private readonly DataContext _context;
    public ClasRepository(DataContext context)
    {
        _context = context;
    }


    public List<GetClasDto> GetClas()
    {
        
        return _context.Classes.Select(x => new GetClasDto { ClassId = x.ClassId, Section = x.Section, SchoolId = x.SchoolId })
            .ToList();
    }

    public GetClasDto GetClas(int id)
    {
        
        var clas = _context.Classes.FirstOrDefault(x => x.ClassId == id);
        if (clas != null)
        {
            return new GetClasDto{ClassId = clas.ClassId, Section = clas.Section, SchoolId = clas.SchoolId};
            
        }
        return null;
    }

    public string CreateClas(CreateUpdateClasDto clasDto)
    {
        if (clasDto == null)
        {
            return "something is wrong";
            
        }
        if (_context.Classes.Any(x=>x.Section==clasDto.Section && x.SchoolId==clasDto.SchoolId))
        {
            return $"this section already exists";
            
        }
        else
        {
            var clas = new Clas { Section =  clasDto.Section, SchoolId = clasDto.SchoolId };
            _context.Classes.Add(clas);
            _context.SaveChanges();
            return $"class {clas.ClassId} added";

        }
        
    }

    public string UpdateClas(int id, CreateUpdateClasDto clasDto)
    {
        if (clasDto == null)
        {
            return "something wrong";
        }

        var clas = _context.Classes.FirstOrDefault(x => x.ClassId == id);

        if (clas == null)
        {
            return $"class {id} not found";
        }

        if (_context.Classes.Any(x =>
                x.ClassId != id &&
                x.Section == clasDto.Section &&
                x.SchoolId == clasDto.SchoolId))
        {
            return $"class already exists";
        }

        clas.Section = clasDto.Section;
        clas.SchoolId = clasDto.SchoolId;

        _context.SaveChanges();

        return $"class {id} updated";
    }

    public string DeleteClas(int id)
    {
        var clas= _context.Classes.FirstOrDefault(x=>x.ClassId == id);
        if (clas != null)
        {
            _context.Classes.Remove(clas);
            
            _context.SaveChanges();
            return $"class {id} deleted";
            
        }
        else
        {
            return $"class {id} not found";
        }
    }
}