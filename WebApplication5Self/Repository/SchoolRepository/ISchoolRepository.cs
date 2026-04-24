using WebApplication5Self.Model;
using WebApplication5Self.Model.Dto.SchoolDto;

namespace WebApplication5Self.Repository;

public interface ISchoolRepository
{
    public Task<List<GetSchoolDto>> GetSchool();
    public Task<GetSchoolDto> GetSchool(int id);
    public Task<string> CreateSchool(CreateUpdateSchoolDto schoolDto);
    public Task<string> UpdateSchool(int id,CreateUpdateSchoolDto schoolDto);
    public Task<string> DeleteSchool(int id);
}