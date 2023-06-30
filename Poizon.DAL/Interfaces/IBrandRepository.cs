using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface IBrandRepository : IBaseRepository<Brand>
{
    Task<Brand> GetBrandByName(string name);
}

