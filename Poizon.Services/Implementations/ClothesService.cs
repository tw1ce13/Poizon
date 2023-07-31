using System.Runtime.InteropServices;
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
    private readonly ISizeRepository _sizeRepository;
    public ClothesService(ISizeRepository sizeRepository ,ISubSubCategoryRepository subSubCategoryRepository, IClothesRepository clothesRepository, IBrandRepository brandRepository, ICategoryRepository categoryRepository,
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
        _sizeRepository = sizeRepository;
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

    public async Task<IBaseResponse<ClothesWithName>> AddClothesByAdmin(ClothesWithName clothes)
    {
        await AddIfNotExist(clothes);
        var brand = await _brandRepository.GetBrandByName(clothes.BrandName);
        var category = await _categoryRepository.GetCategoryByName(clothes.CategoryName);
        var subCategory = await _subCategoryRepository.GetSubCategoryByName(clothes.SubCategoryName);
        var subSubCategory = await _subSubCategoryRepository.GetSubSubCategoryByName(clothes.SubSubCategoryName);
        var model = await _modelRepository.GetModelByName(clothes.ModelName);
        var size = await _sizeRepository.GetSizeByName(clothes.SizeName);
        var style = await _styleRepository.GetStyleByName(clothes.StyleName);
        var sex = await _sexRepository.GetSexByName(clothes.SexName);

        // Теперь вы можете создать объект с именами вместо ID
        var cloth = new Clothes
        {
            BrandId = brand.Id,
            CategoryId = category.Id,
            SubCategoryId = subCategory.Id,
            SubSubCategoryId = subSubCategory.Id,
            ModelId = model.Id,
            SizeId = size.Id,
            StyleId = style.Id,
            SexId = sex.Id,
            Cost = clothes.Price,
            Photo = clothes.Photo,
            Photo1 = clothes.Photo1,
            Photo2 = clothes.Photo2,
            Photo3 = clothes.Photo3,
            Photo4 = clothes.Photo4,
            Photo5 = clothes.Photo5,
            Description = clothes.Description
        };
        await _clothesRespository.Add(cloth);
        var clothesWithName = new ClothesWithName
        {
            Id = cloth.Id,
            BrandName = brand.Name,
            CategoryName = category.Name,
            SubCategoryName = subCategory.Name,
            SubSubCategoryName = subSubCategory.Name,
            ModelName = model.Name,
            SizeName = size.Name,
            StyleName = style.Name,
            SexName = sex.Name,
            Price = clothes.Price,
            Photo = clothes.Photo,
            Photo1 = clothes.Photo1,
            Photo2 = clothes.Photo2,
            Photo3 = clothes.Photo3,
            Photo4 = clothes.Photo4,
            Photo5 = clothes.Photo5,
            Description = clothes.Description
        };
        return new BaseResponse<ClothesWithName>
        {
            Data = clothesWithName,
            Description = "Success",
            StatusCode = Domain.Enums.StatusCode.OK
        };
    }

    private async Task AddIfNotExist(ClothesWithName clothes)
    { 

        var brand = await _brandRepository.GetBrandByName(clothes.BrandName);
        if (brand == null)
        {
            brand = new Brand
            {
                Name = clothes.BrandName
            };
            await _brandRepository.Add(brand);
        }
        var subCategory = await _subCategoryRepository.GetSubCategoryByName(clothes.SubCategoryName);
        var category = await _categoryRepository.GetCategoryByName(clothes.CategoryName);
        if (subCategory == null)
        {
            subCategory = new SubCategory
            {
                Name = clothes.SubCategoryName,
                CategoryId = category.Id
            };
            await _subCategoryRepository.Add(subCategory);
        }
        var subSubCategory = await _subSubCategoryRepository.GetSubSubCategoryByName(clothes.SubSubCategoryName);
        if (subSubCategory == null)
        {
            subSubCategory = new SubSubCategory
            {
                Name = clothes.SubSubCategoryName,
                SubCategoryId = subCategory.Id
            };
            await _subSubCategoryRepository.Add(subSubCategory);
        }
        var model = await _modelRepository.GetModelByName(clothes.ModelName);
        if (model == null)
        {
            model = new Model
            {
                Name = clothes.ModelName,
                BrandId = (await _brandRepository.GetBrandByName(clothes.BrandName)).Id
            };
            await _modelRepository.Add(model);
        }
        var size = await _sizeRepository.GetSizeByName(clothes.SizeName);
        if (size == null)
        {
            size = new Size
            {
                Name = clothes.SizeName
            };
            await _sizeRepository.Add(size);
        }
        var sex = await _sexRepository.GetSexByName(clothes.SexName);
        if (sex == null)
        {
            sex = new Sex
            {
                Name = clothes.SexName
            };
            await _sexRepository.Add(sex);
        }
        var style = await _styleRepository.GetStyleByName(clothes.StyleName);
        if (style == null)
        {
            style = new Style
            {
                Name = clothes.StyleName
            };
            await _styleRepository.Add(style);
        }
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
        var filteredItems = clothes.Where(item =>
            (catalogFilters.CategoryId == 0 || item.CategoryId == catalogFilters.CategoryId) &&
            (catalogFilters.SubCategoryId == 0 || item.SubCategoryId == catalogFilters.SubCategoryId) &&
            (catalogFilters.SubSubCategoryId == 0 || item.SubSubCategoryId == catalogFilters.SubSubCategoryId) &&
            (catalogFilters.BrandId == 0 || item.BrandId == catalogFilters.BrandId) &&
            (catalogFilters.ModelId == 0 || item.ModelId == catalogFilters.ModelId) &&
            (catalogFilters.SexId == 0 || item.SexId == catalogFilters.SexId) &&
            (catalogFilters.StyleId == 0 || item.StyleId == catalogFilters.StyleId)
        );

        var brandList = await _brandRepository.GetAll();
        var categoryList = await _categoryRepository.GetAll();
        var modelList = await _modelRepository.GetAll();
        var sexList = await _sexRepository.GetAll();
        var subCategoryList = await _subCategoryRepository.GetAll();
        var subSubCategoryList = await _subSubCategoryRepository.GetAll();
        var styleList = await _styleRepository.GetAll();
        var sizeList = await _sizeRepository.GetAll();
        var clothesWithNameList = filteredItems.Select(cloth => new ClothesWithName
        {
            Id = cloth.Id,
            BrandName = brandList.FirstOrDefault(b => b.Id == cloth.BrandId)?.Name,
            CategoryName = categoryList.FirstOrDefault(cat => cat.Id == cloth.CategoryId)?.Name,
            ModelName = modelList.FirstOrDefault(m => m.Id == cloth.ModelId)?.Name,
            SexName = sexList.FirstOrDefault(s => s.Id == cloth.SexId)?.Name,
            SubCategoryName = subCategoryList.FirstOrDefault(sc => sc.Id == cloth.SubCategoryId)?.Name,
            SubSubCategoryName = subSubCategoryList.FirstOrDefault(ssc => ssc.Id == cloth.SubSubCategoryId)?.Name,
            StyleName = styleList.FirstOrDefault(st => st.Id == cloth.StyleId)?.Name,
            Price = cloth.Cost,
            Photo = cloth.Photo,
            Photo1 = cloth.Photo1,
            Photo2 = cloth.Photo2,
            Photo3 = cloth.Photo3,
            Photo4 = cloth.Photo4,
            Photo5 = cloth.Photo5,
            Description = cloth.Description,
            SizeName = sizeList.FirstOrDefault(sz => sz.Id == cloth.SizeId)?.Name
        }).ToList();
        return new BaseResponse<IEnumerable<ClothesWithName>>
        {
            Data = clothesWithNameList,
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
        var brandList = await _brandRepository.GetAll();
        var categoryList = await _categoryRepository.GetAll();
        var modelList = await _modelRepository.GetAll();
        var sexList = await _sexRepository.GetAll();
        var subCategoryList = await _subCategoryRepository.GetAll();
        var subSubCategoryList = await _subSubCategoryRepository.GetAll();
        var styleList = await _styleRepository.GetAll();
        var sizeList = await _sizeRepository.GetAll();
        var clothesWithNameList = clothes.Select(cloth => new ClothesWithName
        {
            Id = cloth.Id,
            BrandName = brandList.FirstOrDefault(b => b.Id == cloth.BrandId)?.Name,
            CategoryName = categoryList.FirstOrDefault(cat => cat.Id == cloth.CategoryId)?.Name,
            ModelName = modelList.FirstOrDefault(m => m.Id == cloth.ModelId)?.Name,
            SexName = sexList.FirstOrDefault(s => s.Id == cloth.SexId)?.Name,
            SubCategoryName = subCategoryList.FirstOrDefault(sc => sc.Id == cloth.SubCategoryId)?.Name,
            SubSubCategoryName = subSubCategoryList.FirstOrDefault(ssc => ssc.Id == cloth.SubSubCategoryId)?.Name,
            StyleName = styleList.FirstOrDefault(st => st.Id == cloth.StyleId)?.Name,
            Price = cloth.Cost,
            Photo = cloth.Photo,
            Photo1 = cloth.Photo1,
            Photo2 = cloth.Photo2,
            Photo3 = cloth.Photo3,
            Photo4 = cloth.Photo4,
            Photo5 = cloth.Photo5,
            Description = cloth.Description,
            SizeName = sizeList.FirstOrDefault(sz => sz.Id == cloth.SizeId)?.Name
        }).ToList();

        return new BaseResponse<IEnumerable<ClothesWithName>>
        {
            Data = clothesWithNameList,
            Description = "Succes",
            StatusCode = Domain.Enums.StatusCode.OK
        };
    }

    public async Task<IBaseResponse<ClothesWithName>> GetByIdWithName(long id)
    {
        var baseResponse = new BaseResponse<ClothesWithName>();
        var clothes = await _clothesRespository.GetById(id);
        if (clothes == null)
        {
            baseResponse = new BaseResponse<ClothesWithName>
            {
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        // Предположим, у вас есть метод для получения одного объекта по ID из каждого репозитория
        var brand = await _brandRepository.GetById(clothes.BrandId);
        var category = await _categoryRepository.GetById(clothes.CategoryId);
        var model = await _modelRepository.GetById(clothes.ModelId);
        var sex = await _sexRepository.GetById(clothes.SexId);
        var style = await _styleRepository.GetById(clothes.StyleId);
        var subCategory = await _subCategoryRepository.GetById(clothes.SubCategoryId);
        var subSubCategory = await _subSubCategoryRepository.GetById(clothes.SubSubCategoryId);
        var size = await _sizeRepository.GetById(clothes.SizeId);
        // Теперь вы можете создать объект с именами вместо ID
        var clotheshWithName = new ClothesWithName
        {
            Id = clothes.Id,
            BrandName = brand.Name,
            CategoryName = category.Name,
            ModelName = model.Name,
            SexName = sex.Name,
            SubCategoryName = subCategory.Name,
            SubSubCategoryName = subSubCategory.Name,
            StyleName = style.Name,
            Price = clothes.Cost,
            Photo = clothes.Photo,
            Photo1 = clothes.Photo1,
            Photo2 = clothes.Photo2,
            Photo3 = clothes.Photo3,
            Photo4 = clothes.Photo4,
            Photo5 = clothes.Photo5,
            Description = clothes.Description,
            SizeName = size.Name
        };


        return new BaseResponse<ClothesWithName>
        {
            Data = clotheshWithName,
            Description = "Succes",
            StatusCode = Domain.Enums.StatusCode.OK
        };
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



    async Task<IBaseResponse<Clothes>> IBaseService<Clothes>.GetById(long id)
    {
        var baseResponse = new BaseResponse<Clothes>();
        var cloth = await _clothesRespository.GetById(id);
        if (cloth != null)
        {
            return baseResponse = new BaseResponse<Clothes>
            {
                Data = cloth,
                Description = "Succes",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        return baseResponse = new BaseResponse<Clothes>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
    }

    public async Task<IBaseResponse<ClothesWithName>> UpdateClothesByAdmin(ClothesWithName clothes)
    {
        int categoryNum, subCategoryNum, subSubCategoryNum = 0;
        int.TryParse(clothes.CategoryName, out categoryNum);
        int.TryParse(clothes.SubCategoryName, out subCategoryNum);
        int.TryParse(clothes.SubSubCategoryName, out subSubCategoryNum);
        await AddIfNotExist(clothes);
        var brand = await _brandRepository.GetBrandByName(clothes.BrandName);
        var category = await _categoryRepository.GetById(categoryNum);
        var subCategory = await _subCategoryRepository.GetById(subCategoryNum);
        var subSubCategory = await _subSubCategoryRepository.GetById(subSubCategoryNum);
        var model = await _modelRepository.GetModelByName(clothes.ModelName);
        var size = await _sizeRepository.GetSizeByName(clothes.SizeName);
        var style = await _styleRepository.GetStyleByName(clothes.StyleName);
        var sex = await _sexRepository.GetSexByName(clothes.SexName);

        // Теперь вы можете создать объект с именами вместо ID
        var cloth = new Clothes
        {
            Id = clothes.Id,
            BrandId = brand.Id,
            CategoryId = category.Id,
            SubCategoryId = subCategory.Id,
            SubSubCategoryId = subSubCategory.Id,
            ModelId = model.Id,
            SizeId = size.Id,
            StyleId = style.Id,
            SexId = sex.Id,
            Cost = clothes.Price,
            Photo = clothes.Photo,
            Photo1 = clothes.Photo1,
            Photo2 = clothes.Photo2,
            Photo3 = clothes.Photo3,
            Photo4 = clothes.Photo4,
            Photo5 = clothes.Photo5,
            Description = clothes.Description
        };
        await _clothesRespository.Update(cloth);
        var clothesWithName = new ClothesWithName
        {
            Id = cloth.Id,
            BrandName = brand.Name,
            CategoryName = category.Name,
            SubCategoryName = subCategory.Name,
            SubSubCategoryName = subSubCategory.Name,
            ModelName = model.Name,
            SizeName = size.Name,
            StyleName = style.Name,
            SexName = sex.Name,
            Price = clothes.Price,
            Photo = clothes.Photo,
            Photo1 = clothes.Photo1,
            Photo2 = clothes.Photo2,
            Photo3 = clothes.Photo3,
            Photo4 = clothes.Photo4,
            Photo5 = clothes.Photo5,
            Description = clothes.Description
        };
        return new BaseResponse<ClothesWithName>
        {
            Data = clothesWithName,
            Description = "Success",
            StatusCode = Domain.Enums.StatusCode.OK
        };
    }
}

