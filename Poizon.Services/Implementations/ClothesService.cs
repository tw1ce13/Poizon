using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Services.Interfaces;

namespace Poizon.Services.Implementations;

public class ClothesService : IClothesService
{
	private readonly IClothesRepository _clothesRespository;
	public ClothesService(IClothesRepository clothesRepository)
	{
		_clothesRespository = clothesRepository;
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

