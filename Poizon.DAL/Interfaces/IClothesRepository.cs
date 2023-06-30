using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface IClothesRepository : IBaseRepository<Clothes>
{
    Task<IEnumerable<Clothes>> GetClothesByCategoryId(int id);
    Task<IEnumerable<Clothes>> GetClothesBySubCategoryId(int id);
    Task<IEnumerable<Clothes>> GetClothesByBrandId(int id);
    Task<IEnumerable<Clothes>> GetClothesByModelId(int id);
    Task<IEnumerable<Clothes>> GetClothesByStyleId(int id);
    Task<IEnumerable<Clothes>> GetClothesBySexId(int id);
    Task<IEnumerable<Clothes>> GetClothesBySizeId(int id);
    Task<IEnumerable<Clothes>> GetClothesByCost(int minCost, int maxCost);
}

