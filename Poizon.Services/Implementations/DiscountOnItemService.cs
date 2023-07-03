using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Services.Interfaces;

namespace Poizon.Services.Implementations;

public class DiscountOnItemService : IDiscountOnItemService
{
    private readonly IDiscountOnItemRepository _discountOnItemRepository;

    public DiscountOnItemService(IDiscountOnItemRepository discountOnItemRepository)
    {
        _discountOnItemRepository = discountOnItemRepository;
    }

    public async Task<IBaseResponse<DiscountOnItem>> Add(DiscountOnItem discountOnItem)
    {
        var baseResponse = new BaseResponse<DiscountOnItem>();
        if (discountOnItem != null)
        {
            await _discountOnItemRepository.Add(discountOnItem);
            baseResponse = new BaseResponse<DiscountOnItem>
            {
                Data = discountOnItem,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<DiscountOnItem>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<DiscountOnItem>> Delete(DiscountOnItem discountOnItem)
    {
        var baseResponse = new BaseResponse<DiscountOnItem>();
        if (discountOnItem != null)
        {
            await _discountOnItemRepository.Delete(discountOnItem);
            baseResponse = new BaseResponse<DiscountOnItem>
            {
                Data = discountOnItem,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<DiscountOnItem>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<DiscountOnItem>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<DiscountOnItem>>();
        var discountsOnItem = await _discountOnItemRepository.GetAll();
        if (discountsOnItem != null)
        {
            baseResponse = new BaseResponse<IEnumerable<DiscountOnItem>>
            {
                Data = discountsOnItem,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<IEnumerable<DiscountOnItem>>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<DiscountOnItem>> GetById(long id)
    {
        var baseResponse = new BaseResponse<DiscountOnItem>();
        var data = await _discountOnItemRepository.GetById(id);
        if (data != null)
        {
            baseResponse = new BaseResponse<DiscountOnItem>
            {
                Data = data,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<DiscountOnItem>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<DiscountOnItem>> GetDiscountOnItemByName(string name)
    {
        var baseResponse = new BaseResponse<DiscountOnItem>();
        var data = await _discountOnItemRepository.GetDiscountOnItemByName(name);
        if (data != null)
        {
            baseResponse = new BaseResponse<DiscountOnItem>
            {
                Data = data,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<DiscountOnItem>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<DiscountOnItem>> Update(DiscountOnItem discountOnItem)
    {
        var baseResponse = new BaseResponse<DiscountOnItem>();
        if (discountOnItem != null)
        {
            await _discountOnItemRepository.Update(discountOnItem);
            baseResponse = new BaseResponse<DiscountOnItem>
            {
                Data = discountOnItem,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<DiscountOnItem>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }
}
