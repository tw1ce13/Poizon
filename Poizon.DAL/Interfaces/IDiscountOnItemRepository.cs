using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface IDiscountOnItemRepository : IBaseRepository<DiscountOnItem>
{
    Task<DiscountOnItem> GetDiscountOnItemByName(string name);
}

