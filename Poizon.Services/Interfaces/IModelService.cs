using Poizon.Domain.Models;
using Poizon.Domain.Response;

namespace Poizon.Services.Interfaces;

public interface IModelService : IBaseService<Model>
{
    Task<IBaseResponse<Model>> GetModelByName(string name);
}

