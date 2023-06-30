using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface ISubCategoryRepository : IBaseRepository<SubCategory>
{
	Task<SubCategory> GetSubCategoryByName(string name);
}

