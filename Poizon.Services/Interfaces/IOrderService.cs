using Poizon.Domain.Models;
using Poizon.Domain.Response;

namespace Poizon.Services.Interfaces;

public interface IOrderService : IBaseService<Order>
{
    Task<IBaseResponse<Order>> GetOrderByUserId(long id);
}

