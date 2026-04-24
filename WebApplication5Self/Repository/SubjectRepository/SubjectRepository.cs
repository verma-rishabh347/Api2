using WebApplication5Self.Data;
using WebApplication5Self.Model;
using WebApplication5Self.Model.Dto.SubjectDto;

namespace WebApplication5Self.Repository;

public class SubjectRepository:ISubjectRepository
{
    private readonly DataContext _context;
    public SubjectRepository(DataContext context)
    {
        _context = context;
    }


    public List<GetSubjectDto> GetSubject()
    {
        return _context.Subjects.Select(x=>new GetSubjectDto{Code = x.Code,Name = x.Name ,Id = x.Id}).ToList();
    }

    public GetSubjectDto? GetSubject(int id)
    {
       
        var subject = _context.Subjects.Where(x=>x.Id == id).Select(y => new GetSubjectDto{Code = y.Code,Name = y.Name, Id = y.Id}).FirstOrDefault();
        if (subject == null)
        {
            return null;

        }

        return subject;
    }

    public string CreateSubject(CreateUpdateSubjectDto subject)
    {
        if (subject == null)
        {
            return "something went wrong";
            
        }
        if ( _context.Subjects.Any(x=>x.Code == subject.Code && x.Name == subject.Name))
        {
            return "subjet already exists";
            
        }
        else
        {
            var currentsubject=new Subject{Name = subject.Name, Code = subject.Code,StudentId = subject.StudentId};
            _context.Subjects.Add(currentsubject);
            _context.SaveChanges();
            return "success";
        }
    }

    public string UpdateSubject(int id, CreateUpdateSubjectDto subject)
    {
        if (subject == null)
        {
            return "invalid data";
        }

        var currentSubject = _context.Subjects.FirstOrDefault(x => x.Id == id);

        if (currentSubject == null)
        {
            return "subject not found";
        }

        if (_context.Subjects.Any(x =>
                x.Id != id &&
                (x.Code == subject.Code || x.Name == subject.Name)))
        {
            return "subject already exists";
        }

        currentSubject.Name = subject.Name;
        currentSubject.Code = subject.Code;
        currentSubject.StudentId = subject.StudentId;

        _context.SaveChanges();

        return "success";
    }

    public string DeleteSubject(int id)
    {
        var subject = _context.Subjects.FirstOrDefault(x=>x.Id == id);
        if (subject == null)
        {
            return "something went wrong";
            
        }
        else
        {
            _context.Remove(subject);
            _context.SaveChanges();
            return "success";
            
        }
    }
}