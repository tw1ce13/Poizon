using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface ISexRepository : IBaseRepository<Sex>
{
    Task<Sex> GetSexByName(string name);
}

