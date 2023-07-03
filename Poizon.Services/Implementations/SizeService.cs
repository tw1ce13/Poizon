using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Services.Interfaces;

namespace Poizon.Services.Implementations;

public class SizeService : ISizeService
{
    private readonly ISizeRepository _sizeRepository;

    public SizeService(ISizeRepository sizeRepository)
    {
        _sizeRepository = sizeRepository;
    }

    public async Task<IBaseResponse<Size>> Add(Size size)
    {
        var baseResponse = new BaseResponse<Size>();
        if (size != null)
        {
            await _sizeRepository.Add(size);
            baseResponse = new BaseResponse<Size>
            {
                Data = size,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Size>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Size>> Delete(Size size)
    {
        var baseResponse = new BaseResponse<Size>();
        if (size != null)
        {
            await _sizeRepository.Delete(size);
            baseResponse = new BaseResponse<Size>
            {
                Data = size,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Size>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<Size>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Size>>();
        var sizes = await _sizeRepository.GetAll();
        if (sizes != null)
        {
            baseResponse = new BaseResponse<IEnumerable<Size>>
            {
                Data = sizes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<IEnumerable<Size>>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Size>> GetById(long id)
    {
        var baseResponse = new BaseResponse<Size>();
        var size = await _sizeRepository.GetById(id);
        if (size != null)
        {
            baseResponse = new BaseResponse<Size>
            {
                Data = size,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Size>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Size>> GetSizeByName(string name)
    {
        var baseResponse = new BaseResponse<Size>();
        var size = await _sizeRepository.GetSizeByName(name);
        if (size != null)
        {
            baseResponse = new BaseResponse<Size>
            {
                Data = size,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Size>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Size>> Update(Size size)
    {
        var baseResponse = new BaseResponse<Size>();
        if (size != null)
        {
            await _sizeRepository.Update(size);
            baseResponse = new BaseResponse<Size>
            {
                Data = size,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Size>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }
}
