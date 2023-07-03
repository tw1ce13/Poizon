using Poizon.Domain.Models;
using Poizon.Domain.Response;

namespace Poizon.Services.Interfaces;

public interface ISizeService : IBaseService<Size>
{
    Task<IBaseResponse<Size>> GetSizeByName(string name);
}

