using Poizon.Domain.Helpers;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Domain.ViewModel;

namespace Poizon.Services.Interfaces;

public interface IClothesService : IBaseService<Clothes>
{
    Task<IBaseResponse<IEnumerable<ClothesWithName>>> GetAllWithName();
    Task<IBaseResponse<IEnumerable<ClothesWithName>>> GetAllByFilters(CatalogFilters catalogFilters);
    Task<IBaseResponse<IEnumerable<Clothes>>> GetClothesByCategoryId(long id);
    Task<IBaseResponse<IEnumerable<Clothes>>> GetClothesBySubCategoryId(long id);
    Task<IBaseResponse<IEnumerable<Clothes>>> GetClothesByBrandId(long id);
    Task<IBaseResponse<IEnumerable<Clothes>>> GetClothesByModelId(long id);
    Task<IBaseResponse<IEnumerable<Clothes>>> GetClothesByStyleId(long id);
    Task<IBaseResponse<IEnumerable<Clothes>>> GetClothesBySexId(long id);
    Task<IBaseResponse<IEnumerable<Clothes>>> GetClothesBySizeId(long id);
    Task<IBaseResponse<IEnumerable<Clothes>>> GetClothesByCost(long minCost, long maxCost);
}

