using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<Order> GetOrderByUserId(long id);
}

