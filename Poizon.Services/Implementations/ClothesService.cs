using Poizon.DAL.Interfaces;
using Poizon.Domain.Helpers;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Domain.ViewModel;
using Poizon.Services.Interfaces;

namespace Poizon.Services.Implementations;

public class ClothesService : IClothesService
{
	private readonly IClothesRepository _clothesRespository;
    private readonly IBrandRepository _brandRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly ISexRepository _sexRepository;
    private readonly IStyleRepository _styleRepository;
    private readonly IModelRepository _modelRepository;
    private readonly ISubSubCategoryRepository _subSubCategoryRepository;
    public ClothesService(ISubSubCategoryRepository subSubCategoryRepository, IClothesRepository clothesRepository, IBrandRepository brandRepository, ICategoryRepository categoryRepository,
        ISubCategoryRepository subCategoryRepository, ISexRepository sexRepository, IStyleRepository styleRepository, IModelRepository modelRepository)
	{
		_clothesRespository = clothesRepository;
        _brandRepository = brandRepository;
        _categoryRepository = categoryRepository;
        _sexRepository = sexRepository;
        _styleRepository = styleRepository;
        _subCategoryRepository = subCategoryRepository;
        _modelRepository = modelRepository;
        _subSubCategoryRepository = subSubCategoryRepository;
	}

    public async Task<IBaseResponse<Clothes>> Add(Clothes clothes)
    {
        var baseResponse = new BaseResponse<Clothes>();
        if (clothes != null)
        {
            await _clothesRespository.Add(clothes);
            baseResponse = new BaseResponse<Clothes>
            {
                Data = clothes,
                Description = "Succes",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Clothes>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<Clothes>> Delete(Clothes clothes)
    {
        var baseResponse = new BaseResponse<Clothes>();
        if (clothes != null)
        {
            await _clothesRespository.Delete(clothes);
            baseResponse = new BaseResponse<Clothes>
            {
                Data = clothes,
                Description = "Succes",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Clothes>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<Clothes>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Clothes>>();
        var clothes = await _clothesRespository.GetAll();
        if (clothes != null)
        {
            baseResponse = new BaseResponse<IEnumerable<Clothes>>
            {
                Data = clothes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<IEnumerable<Clothes>>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<ClothesWithName>>> GetAllByFilters(CatalogFilters catalogFilters)
    {
        var clothes = await _clothesRespository.GetAll();
        if (clothes == null)
        {
            return new BaseResponse<IEnumerable<ClothesWithName>>
            {
                Description = "Ничего не найдено",
                StatusCode = Domain.Enums.StatusCode.ObjectNotFound
            };
        }
        var filteresClothes = clothes.Where(c =>
            (catalogFilters.CategoryId == 0 || c.CategoryId == catalogFilters.CategoryId) &&
            (catalogFilters.SubCategoryId == 0 || c.SubCategoryId == catalogFilters.SubCategoryId) &&
            (catalogFilters.BrandId == 0 || c.BrandId == catalogFilters.BrandId) &&
            (catalogFilters.ModelId == 0 || c.ModelId == catalogFilters.ModelId) &&
            (catalogFilters.SexId == 0 || c.SexId == catalogFilters.SexId) &&
            (catalogFilters.StyleId == 0 || c.StyleId == catalogFilters.StyleId));

        var result = from cloth in filteresClothes
                     join brand in await _brandRepository.GetAll() on cloth.BrandId equals brand.Id
                     join category in await _categoryRepository.GetAll() on cloth.Id equals category.Id
                     join model in await _modelRepository.GetAll() on cloth.ModelId equals model.Id
                     join sex in await _sexRepository.GetAll() on cloth.SexId equals sex.Id
                     join style in await _styleRepository.GetAll() on cloth.StyleId equals style.Id
                     join subCategory in await _subCategoryRepository.GetAll() on cloth.SubCategoryId equals subCategory.Id
                     join subSubCategory in await _subSubCategoryRepository.GetAll() on cloth.SubSubCategoryId equals subSubCategory.Id
                     select new ClothesWithName
                     {
                         Id = cloth.Id,
                         BrandName = brand.Name,
                         CategoryName = category.Name,
                         ModelName = model.Name,
                         SexName = sex.Name,
                         SubCategoryName = subCategory.Name,
                         SubSubCategoryName = subSubCategory.Name,
                         StyleName = style.Name,
                         Price = cloth.Cost,
                         Photo = cloth.Photo
                     };
        return new BaseResponse<IEnumerable<ClothesWithName>>
        {
            Data = result,
            Description = "Succes",
            StatusCode = Domain.Enums.StatusCode.OK
        };
    }

    public async Task<IBaseResponse<IEnumerable<ClothesWithName>>> GetAllWithName()
    {
        var clothes = await _clothesRespository.GetAll();
        if (clothes == null)
        {
            return new BaseResponse<IEnumerable<ClothesWithName>>
            {
                Description = "Не найдено элементов",
                StatusCode = Domain.Enums.StatusCode.ObjectNotFound
            };
        }
        var result = from cloth in clothes
                     join brand in await _brandRepository.GetAll() on cloth.BrandId equals brand.Id
                     join category in await _categoryRepository.GetAll() on cloth.Id equals category.Id
                     join model in await _modelRepository.GetAll() on cloth.ModelId equals model.Id
                     join sex in await _sexRepository.GetAll() on cloth.SexId equals sex.Id
                     join style in await _styleRepository.GetAll() on cloth.StyleId equals style.Id
                     join subCategory in await _subCategoryRepository.GetAll() on cloth.SubCategoryId equals subCategory.Id
                     join subSubCategory in await _subSubCategoryRepository.GetAll() on cloth.SubSubCategoryId equals subSubCategory.Id
                     select new ClothesWithName
                     {
                         Id = cloth.Id,
                         BrandName = brand.Name,
                         CategoryName = category.Name,
                         ModelName = model.Name,
                         SexName = sex.Name,
                         SubCategoryName = subCategory.Name,
                         SubSubCategoryName = subSubCategory.Name,
                         StyleName = style.Name,
                         Price = cloth.Cost,
                         Photo = cloth.Photo
                     };
        return new BaseResponse<IEnumerable<ClothesWithName>>
        {
            Data = result,
            Description = "Succes",
            StatusCode = Domain.Enums.StatusCode.OK
        };
    }

    public async Task<IBaseResponse<Clothes>> GetById(long id)
    {
        var baseResponse = new BaseResponse<Clothes>();
        var clothes = await _clothesRespository.GetById(id);
        if (clothes != null)
        {
            baseResponse = new BaseResponse<Clothes>
            {
                Data = clothes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Clothes>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<Clothes>>> GetClothesByBrandId(long id)
    {
        var baseResponse = new BaseResponse<IEnumerable<Clothes>>();
        var clothes = await _clothesRespository.GetClothesByBrandId(id);
        if (clothes != null)
        {
            baseResponse = new BaseResponse<IEnumerable<Clothes>>
            {
                Data = clothes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<IEnumerable<Clothes>>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<Clothes>>> GetClothesByCategoryId(long id)
    {
        var baseResponse = new BaseResponse<IEnumerable<Clothes>>();
        var clothes = await _clothesRespository.GetClothesByCategoryId(id);
        if (clothes != null)
        {
            baseResponse = new BaseResponse<IEnumerable<Clothes>>
            {
                Data = clothes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<IEnumerable<Clothes>>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<Clothes>>> GetClothesByCost(long minCost, long maxCost)
    {
        var baseResponse = new BaseResponse<IEnumerable<Clothes>>();
        var clothes = await _clothesRespository.GetClothesByCost(minCost, maxCost);
        if (clothes != null)
        {
            baseResponse = new BaseResponse<IEnumerable<Clothes>>
            {
                Data = clothes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<IEnumerable<Clothes>>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<Clothes>>> GetClothesByModelId(long id)
    {
        var baseResponse = new BaseResponse<IEnumerable<Clothes>>();
        var clothes = await _clothesRespository.GetClothesByModelId(id);
        if (clothes != null)
        {
            baseResponse = new BaseResponse<IEnumerable<Clothes>>
            {
                Data = clothes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<IEnumerable<Clothes>>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<Clothes>>> GetClothesBySexId(long id)
    {
        var baseResponse = new BaseResponse<IEnumerable<Clothes>>();
        var clothes = await _clothesRespository.GetClothesBySexId(id);
        if (clothes != null)
        {
            baseResponse = new BaseResponse<IEnumerable<Clothes>>
            {
                Data = clothes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<IEnumerable<Clothes>>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<Clothes>>> GetClothesBySizeId(long id)
    {
        var baseResponse = new BaseResponse<IEnumerable<Clothes>>();
        var clothes = await _clothesRespository.GetClothesBySizeId(id);
        if (clothes != null)
        {
            baseResponse = new BaseResponse<IEnumerable<Clothes>>
            {
                Data = clothes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<IEnumerable<Clothes>>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<Clothes>>> GetClothesByStyleId(long id)
    {
        var baseResponse = new BaseResponse<IEnumerable<Clothes>>();
        var clothes = await _clothesRespository.GetClothesByStyleId(id);
        if (clothes != null)
        {
            baseResponse = new BaseResponse<IEnumerable<Clothes>>
            {
                Data = clothes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<IEnumerable<Clothes>>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<Clothes>>> GetClothesBySubCategoryId(long id)
    {
        var baseResponse = new BaseResponse<IEnumerable<Clothes>>();
        var clothes = await _clothesRespository.GetClothesBySubCategoryId(id);
        if (clothes != null)
        {
            baseResponse = new BaseResponse<IEnumerable<Clothes>>
            {
                Data = clothes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<IEnumerable<Clothes>>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<Clothes>> Update(Clothes clothes)
    {
        var baseResponse = new BaseResponse<Clothes>();
        if (clothes != null)
        {
            await _clothesRespository.Update(clothes);
            baseResponse = new BaseResponse<Clothes>
            {
                Data = clothes,
                Description = "Succes",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Clothes>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }
}

