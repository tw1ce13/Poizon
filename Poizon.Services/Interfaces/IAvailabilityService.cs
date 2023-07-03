using Poizon.Domain.Models;
using Poizon.Domain.Response;

namespace Poizon.Services.Interfaces;

public interface IAvailabilityService : IBaseService<Availability>
{
    Task<IBaseResponse<int>> GetCountByClothesId(long id);
}

