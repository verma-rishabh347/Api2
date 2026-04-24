using WebApplication5Self.Model;
using WebApplication5Self.Model.Dto.StudentDto;

namespace WebApplication5Self.Repository;

public interface IStudentRepository
{
    public List<GetStudentDto> GetStudent();
    public GetStudentDto GetStudent(int id);
    public string CreateStudent(CreateUpdateStudentDto subject);
    public string UpdateStudent(int id,CreateUpdateStudentDto subject);
    public string DeleteStudent(int id);
}