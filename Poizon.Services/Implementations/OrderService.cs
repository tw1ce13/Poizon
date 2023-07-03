using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Services.Interfaces;

namespace Poizon.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IBaseResponse<Order>> Add(Order order)
    {
        var baseResponse = new BaseResponse<Order>();
        if (order != null)
        {
            await _orderRepository.Add(order);
            baseResponse = new BaseResponse<Order>
            {
                Data = order,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Order>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Order>> Delete(Order order)
    {
        var baseResponse = new BaseResponse<Order>();
        if (order != null)
        {
            await _orderRepository.Delete(order);
            baseResponse = new BaseResponse<Order>
            {
                Data = order,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Order>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<Order>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Order>>();
        var orders = await _orderRepository.GetAll();
        if (orders != null)
        {
            baseResponse = new BaseResponse<IEnumerable<Order>>
            {
                Data = orders,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<IEnumerable<Order>>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Order>> GetById(long id)
    {
        var baseResponse = new BaseResponse<Order>();
        var order = await _orderRepository.GetById(id);
        if (order != null)
        {
            baseResponse = new BaseResponse<Order>
            {
                Data = order,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Order>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Order>> GetOrderByUserId(long id)
    {
        var baseResponse = new BaseResponse<Order>();
        var order = await _orderRepository.GetOrderByUserId(id);
        if (order != null)
        {
            baseResponse = new BaseResponse<Order>
            {
                Data = order,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Order>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<Order>> Update(Order order)
    {
        var baseResponse = new BaseResponse<Order>();
        if (order != null)
        {
            await _orderRepository.Update(order);
            baseResponse = new BaseResponse<Order>
            {
                Data = order,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<Order>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }
}
