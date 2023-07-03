using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Services.Interfaces;

namespace Poizon.Services.Implementations;

public class DiscountOnOrderService : IDiscountOnOrderService
{
    private readonly IDiscountOnOrderRepository _discountOnOrderRepository;

    public DiscountOnOrderService(IDiscountOnOrderRepository discountOnOrderRepository)
    {
        _discountOnOrderRepository = discountOnOrderRepository;
    }

    public async Task<IBaseResponse<DiscountOnOrder>> Add(DiscountOnOrder discountOnOrder)
    {
        var baseResponse = new BaseResponse<DiscountOnOrder>();
        if (discountOnOrder != null)
        {
            await _discountOnOrderRepository.Add(discountOnOrder);
            baseResponse = new BaseResponse<DiscountOnOrder>
            {
                Data = discountOnOrder,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<DiscountOnOrder>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<DiscountOnOrder>> Delete(DiscountOnOrder discountOnOrder)
    {
        var baseResponse = new BaseResponse<DiscountOnOrder>();
        if (discountOnOrder != null)
        {
            await _discountOnOrderRepository.Delete(discountOnOrder);
            baseResponse = new BaseResponse<DiscountOnOrder>
            {
                Data = discountOnOrder,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<DiscountOnOrder>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<DiscountOnOrder>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<DiscountOnOrder>>();
        var discountsOnOrder = await _discountOnOrderRepository.GetAll();
        if (discountsOnOrder != null)
        {
            baseResponse = new BaseResponse<IEnumerable<DiscountOnOrder>>
            {
                Data = discountsOnOrder,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<IEnumerable<DiscountOnOrder>>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<DiscountOnOrder>> GetById(long id)
    {
        var baseResponse = new BaseResponse<DiscountOnOrder>();
        var data = await _discountOnOrderRepository.GetById(id);
        if (data != null)
        {
            baseResponse = new BaseResponse<DiscountOnOrder>
            {
                Data = data,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<DiscountOnOrder>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<DiscountOnOrder>> GetDiscountOnOrderByName(string name)
    {
        var baseResponse = new BaseResponse<DiscountOnOrder>();
        var data = await _discountOnOrderRepository.GetDiscountOnOrderByName(name);
        if (data != null)
        {
            baseResponse = new BaseResponse<DiscountOnOrder>
            {
                Data = data,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<DiscountOnOrder>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<DiscountOnOrder>> Update(DiscountOnOrder discountOnOrder)
    {
        var baseResponse = new BaseResponse<DiscountOnOrder>();
        if (discountOnOrder != null)
        {
            await _discountOnOrderRepository.Update(discountOnOrder);
            baseResponse = new BaseResponse<DiscountOnOrder>
            {
                Data = discountOnOrder,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<DiscountOnOrder>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }
}
