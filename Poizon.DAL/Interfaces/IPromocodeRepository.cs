using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface IPromocodeRepository : IBaseRepository<Promocode>
{
    Task<Promocode> GetPromocodeByName(string name);
}

