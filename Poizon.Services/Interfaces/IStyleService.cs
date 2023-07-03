using Poizon.Domain.Models;
using Poizon.Domain.Response;

namespace Poizon.Services.Interfaces;

public interface IStyleService : IBaseService<Style>
{
    Task<IBaseResponse<Style>> GetStyleByName(string name);
}

