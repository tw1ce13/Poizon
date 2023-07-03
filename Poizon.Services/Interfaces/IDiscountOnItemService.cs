using Poizon.Domain.Models;
using Poizon.Domain.Response;

namespace Poizon.Services.Interfaces;

public interface IDiscountOnItemService : IBaseService<DiscountOnItem>
{
    Task<IBaseResponse<DiscountOnItem>> GetDiscountOnItemByName(string name);
}

