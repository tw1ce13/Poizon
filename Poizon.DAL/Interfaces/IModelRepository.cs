using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface IModelRepository : IBaseRepository<Model>
{
    Task<Model> GetModelByName(string name);
}

