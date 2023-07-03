using Poizon.Domain.Models;
using Poizon.Domain.Response;

namespace Poizon.Services.Interfaces;

public interface ISubCategoryService : IBaseService<SubCategory>
{
    Task<IBaseResponse<SubCategory>> GetSubCategoryByName(string name);
}

