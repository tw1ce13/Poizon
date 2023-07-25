using Poizon.Domain.Models;
using Poizon.Domain.Response;

namespace Poizon.Services.Interfaces;

public interface ICategoryService : IBaseService<Category>
{
    Task<IBaseResponse<Category>> GetCategoryByName(string name);
}

