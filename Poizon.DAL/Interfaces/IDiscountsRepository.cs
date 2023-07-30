using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface IDiscountsRepository : IBaseRepository<Discounts>
{
    Task<Discounts> GetDiscountByName(string name);
}

