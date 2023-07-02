using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface IClothesRepository : IBaseRepository<Clothes>
{
    Task<IEnumerable<Clothes>> GetClothesByCategoryId(long id);
    Task<IEnumerable<Clothes>> GetClothesBySubCategoryId(long id);
    Task<IEnumerable<Clothes>> GetClothesByBrandId(long id);
    Task<IEnumerable<Clothes>> GetClothesByModelId(long id);
    Task<IEnumerable<Clothes>> GetClothesByStyleId(long id);
    Task<IEnumerable<Clothes>> GetClothesBySexId(long id);
    Task<IEnumerable<Clothes>> GetClothesBySizeId(long id);
    Task<IEnumerable<Clothes>> GetClothesByCost(long minCost, long maxCost);
}