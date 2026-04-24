using WebApplication5Self.Model;
using WebApplication5Self.Model.Dto.SubjectDto;

namespace WebApplication5Self.Repository;

public interface ISubjectRepository
{
    public List<GetSubjectDto> GetSubject();
    public GetSubjectDto GetSubject(int id);
    public string CreateSubject(CreateUpdateSubjectDto subject);
    public string UpdateSubject(int id,CreateUpdateSubjectDto subject);
    public string DeleteSubject(int id);
}