using Poizon.Domain.Models;
using Poizon.Domain.Response;

namespace Poizon.Services.Interfaces;

public interface ISexService : IBaseService<Sex>
{
    Task<IBaseResponse<Sex>> GetSexByName(string name);
}

