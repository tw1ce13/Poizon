using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Services.Interfaces;

namespace Poizon.Services.Implementations;

public class OrderClothesService : IOrderClothesService
{
    private readonly IOrderClothesRepository _orderClothesRepository;

    public OrderClothesService(IOrderClothesRepository orderClothesRepository)
    {
        _orderClothesRepository = orderClothesRepository;
    }

    public async Task<IBaseResponse<OrderClothes>> Add(OrderClothes orderClothes)
    {
        var baseResponse = new BaseResponse<OrderClothes>();
        if (orderClothes != null)
        {
            await _orderClothesRepository.Add(orderClothes);
            baseResponse = new BaseResponse<OrderClothes>
            {
                Data = orderClothes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<OrderClothes>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<OrderClothes>> Delete(OrderClothes orderClothes)
    {
        var baseResponse = new BaseResponse<OrderClothes>();
        if (orderClothes != null)
        {
            await _orderClothesRepository.Delete(orderClothes);
            baseResponse = new BaseResponse<OrderClothes>
            {
                Data = orderClothes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<OrderClothes>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<OrderClothes>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<OrderClothes>>();
        var ordersClothes = await _orderClothesRepository.GetAll();
        if (ordersClothes != null)
        {
            baseResponse = new BaseResponse<IEnumerable<OrderClothes>>
            {
                Data = ordersClothes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<IEnumerable<OrderClothes>>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<OrderClothes>> GetById(long id)
    {
        var baseResponse = new BaseResponse<OrderClothes>();
        var orderClothes = await _orderClothesRepository.GetById(id);
        if (orderClothes != null)
        {
            baseResponse = new BaseResponse<OrderClothes>
            {
                Data = orderClothes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<OrderClothes>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<OrderClothes>> GetOrderClothesByOrderId(long orderId)
    {
        var baseResponse = new BaseResponse<OrderClothes>();
        var orderClothes = await _orderClothesRepository.GetOrderClothesByOrderId(orderId);
        if (orderClothes != null)
        {
            baseResponse = new BaseResponse<OrderClothes>
            {
                Data = orderClothes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<OrderClothes>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<OrderClothes>> GetOrderClothesByClothesId(long clothesId)
    {
        var baseResponse = new BaseResponse<OrderClothes>();
        var orderClothes = await _orderClothesRepository.GetOrderClothesByClothesId(clothesId);
        if (orderClothes != null)
        {
            baseResponse = new BaseResponse<OrderClothes>
            {
                Data = orderClothes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<OrderClothes>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<OrderClothes>> Update(OrderClothes orderClothes)
    {
        var baseResponse = new BaseResponse<OrderClothes>();
        if (orderClothes != null)
        {
            await _orderClothesRepository.Update(orderClothes);
            baseResponse = new BaseResponse<OrderClothes>
            {
                Data = orderClothes,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<OrderClothes>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }
}
