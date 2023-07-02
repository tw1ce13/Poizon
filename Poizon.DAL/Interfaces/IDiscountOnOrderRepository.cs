using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface IDiscountOnOrderRepository : IBaseRepository<DiscountOnOrder>
{
    Task<DiscountOnOrder> GetDiscountOnOrderByName(string name);
}

