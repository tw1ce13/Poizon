using Poizon.Domain.Models;
using Poizon.Domain.Response;

namespace Poizon.Services.Interfaces;

public interface IBrandService : IBaseService<Brand>
{
    Task<IBaseResponse<Brand>> GetBrandByName(string name);
}

