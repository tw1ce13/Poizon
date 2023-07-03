using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Services.Interfaces;

namespace Poizon.Services.Implementations;

public class StyleService : IStyleService
{
    private readonly IStyleRepository _styleRepository;

    public StyleService(IStyleRepository styleRepository)
    {
        _styleRepository = styleRepository;
    }

    public async Task<IBaseResponse<Style>> Add(Style style)
    {
        var baseResponse = new BaseResponse<Style>();
        if (style != null)
        {
            await _styleRepository.Add(style);
            baseResponse = new BaseResponse<Style>
            {
                Data = style,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Style>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Style>> Delete(Style style)
    {
        var baseResponse = new BaseResponse<Style>();
        if (style != null)
        {
            await _styleRepository.Delete(style);
            baseResponse = new BaseResponse<Style>
            {
                Data = style,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Style>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<Style>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Style>>();
        var styles = await _styleRepository.GetAll();
        if (styles != null)
        {
            baseResponse = new BaseResponse<IEnumerable<Style>>
            {
                Data = styles,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<IEnumerable<Style>>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Style>> GetById(long id)
    {
        var baseResponse = new BaseResponse<Style>();
        var style = await _styleRepository.GetById(id);
        if (style != null)
        {
            baseResponse = new BaseResponse<Style>
            {
                Data = style,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Style>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Style>> GetStyleByName(string name)
    {
        var baseResponse = new BaseResponse<Style>();
        var style = await _styleRepository.GetStyleByName(name);
        if (style != null)
        {
            baseResponse = new BaseResponse<Style>
            {
                Data = style,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Style>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Style>> Update(Style style)
    {
        var baseResponse = new BaseResponse<Style>();
        if (style != null)
        {
            await _styleRepository.Update(style);
            baseResponse = new BaseResponse<Style>
            {
                Data = style,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Style>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }
}
