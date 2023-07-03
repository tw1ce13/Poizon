using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Services.Interfaces;

namespace Poizon.Services.Implementations;

public class BrandService : IBrandService
{
	private readonly IBrandRepository _brandRespository;
	public BrandService(IBrandRepository brandRepository)
	{
		_brandRespository = brandRepository;
	}

    public async Task<IBaseResponse<Brand>> Add(Brand brand)
    {
        var baseResponse = new BaseResponse<Brand>();
        if (brand != null)
        {
            await _brandRespository.Add(brand);
            baseResponse = new BaseResponse<Brand>
            {
                Data = brand,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Brand>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<Brand>> Delete(Brand brand)
    {
        var baseResponse = new BaseResponse<Brand>();
        if (brand != null)
        {
            await _brandRespository.Delete(brand);
            baseResponse = new BaseResponse<Brand>
            {
                Data = brand,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Brand>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<Brand>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Brand>>();
        var brands = await _brandRespository.GetAll();
        if (brands != null)
        {
            baseResponse = new BaseResponse<IEnumerable<Brand>>
            {
                Data = brands,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<IEnumerable<Brand>>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<Brand>> GetBrandByName(string name)
    {
        var baseResponse = new BaseResponse<Brand>();
        var brand = await _brandRespository.GetBrandByName(name);
        if (brand != null)
        {
            baseResponse = new BaseResponse<Brand>
            {
                Data = brand,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Brand>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<Brand>> GetById(long id)
    {
        var baseResponse = new BaseResponse<Brand>();
        var brand = await _brandRespository.GetById(id);
        if (brand != null)
        {
            baseResponse = new BaseResponse<Brand>
            {
                Data = brand,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Brand>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<Brand>> Update(Brand brand)
    {
        var baseResponse = new BaseResponse<Brand>();
        if (brand != null)
        {
            await _brandRespository.Update(brand);
            baseResponse = new BaseResponse<Brand>
            {
                Data = brand,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Brand>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }
}

