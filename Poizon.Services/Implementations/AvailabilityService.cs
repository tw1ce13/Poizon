using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Services.Interfaces;

namespace Poizon.Services.Implementations;

public class AvailabilityService : IAvailabilityService
{
	private readonly IAvailabilityRepository _availibilityRepository;
	public AvailabilityService(IAvailabilityRepository availabilityRepository)
	{
		_availibilityRepository = availabilityRepository;
	}

    public async Task<IBaseResponse<Availability>> Add(Availability availability)
    {
        var baseResponse = new BaseResponse<Availability>();
        if (availability != null)
        {
            await _availibilityRepository.Add(availability);
            baseResponse = new BaseResponse<Availability>
            {
                Data = availability,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Availability>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<Availability>> Delete(Availability availability)
    {
        var baseResponse = new BaseResponse<Availability>();
        if (availability != null)
        {
            await _availibilityRepository.Delete(availability);
            baseResponse = new BaseResponse<Availability>
            {
                Data = availability,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Availability>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<Availability>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Availability>>();
        var availabilities = await _availibilityRepository.GetAll();
        if (availabilities != null)
        {
            baseResponse = new BaseResponse<IEnumerable<Availability>>
            {
                Data = availabilities,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<IEnumerable<Availability>>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;

    }

    public async Task<IBaseResponse<Availability>> GetById(long id)
    {
        var baseResponse = new BaseResponse<Availability>();
        var availability = await _availibilityRepository.GetById(id);
        if (availability != null)
        {
            baseResponse = new BaseResponse<Availability>
            {
                Data = availability,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Availability>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<int>> GetCountByClothesId(long id)
    {
        var baseResponse = new BaseResponse<int>();
        var count = await _availibilityRepository.GetCountByClothesId(id);
        baseResponse = new BaseResponse<int>
        {
            Data = count,
            Description = "Success",
            StatusCode = Domain.Enums.StatusCode.OK
        };
        return baseResponse;
    }

    public async Task<IBaseResponse<Availability>> Update(Availability availability)
    {
        var baseResponse = new BaseResponse<Availability>();
        if (availability != null)
        {
            await _availibilityRepository.Update(availability);
            baseResponse = new BaseResponse<Availability>
            {
                Data = availability,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
            return baseResponse;
        }
        baseResponse = new BaseResponse<Availability>
        {
            Description = "Error",
            StatusCode = Domain.Enums.StatusCode.Error
        };
        return baseResponse;
    }
}

