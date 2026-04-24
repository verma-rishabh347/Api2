using WebApplication5Self.Model;
using WebApplication5Self.Model.Dto.ClasDto;

namespace WebApplication5Self.Repository;

public interface IClasRepository
{
    public List<GetClasDto> GetClas();
    public GetClasDto GetClas(int id);
    public string CreateClas(CreateUpdateClasDto clasDto);
    public string UpdateClas(int id,CreateUpdateClasDto clasDto);
    public string DeleteClas(int id);
    
}