using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
	Task<Category> GetCategoryByName(string name);
}

