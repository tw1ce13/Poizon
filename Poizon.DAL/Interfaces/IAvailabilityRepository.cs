using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface IAvailabilityRepository : IBaseRepository<Availability>
{
    Task<int> GetCountByClothesId(int id);
}

