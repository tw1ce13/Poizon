using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Services.Interfaces;

namespace Poizon.Services.Implementations;

public class SexService : ISexService
{
    private readonly ISexRepository _sexRepository;

    public SexService(ISexRepository sexRepository)
    {
        _sexRepository = sexRepository;
    }

    public async Task<IBaseResponse<Sex>> Add(Sex sex)
    {
        var baseResponse = new BaseResponse<Sex>();
        if (sex != null)
        {
            await _sexRepository.Add(sex);
            baseResponse = new BaseResponse<Sex>
            {
                Data = sex,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Sex>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Sex>> Delete(Sex sex)
    {
        var baseResponse = new BaseResponse<Sex>();
        if (sex != null)
        {
            await _sexRepository.Delete(sex);
            baseResponse = new BaseResponse<Sex>
            {
                Data = sex,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Sex>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<Sex>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Sex>>();
        var sexes = await _sexRepository.GetAll();
        if (sexes != null)
        {
            baseResponse = new BaseResponse<IEnumerable<Sex>>
            {
                Data = sexes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<IEnumerable<Sex>>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Sex>> GetById(long id)
    {
        var baseResponse = new BaseResponse<Sex>();
        var sex = await _sexRepository.GetById(id);
        if (sex != null)
        {
            baseResponse = new BaseResponse<Sex>
            {
                Data = sex,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Sex>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Sex>> GetSexByName(string name)
    {
        var baseResponse = new BaseResponse<Sex>();
        var sex = await _sexRepository.GetSexByName(name);
        if (sex != null)
        {
            baseResponse = new BaseResponse<Sex>
            {
                Data = sex,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Sex>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Sex>> Update(Sex sex)
    {
        var baseResponse = new BaseResponse<Sex>();
        if (sex != null)
        {
            await _sexRepository.Update(sex);
            baseResponse = new BaseResponse<Sex>
            {
                Data = sex,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Sex>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }
}
