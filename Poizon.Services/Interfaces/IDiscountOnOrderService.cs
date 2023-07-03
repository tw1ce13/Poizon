using Poizon.Domain.Models;
using Poizon.Domain.Response;

namespace Poizon.Services.Interfaces;

public interface IDiscountOnOrderService : IBaseService<DiscountOnOrder>
{
    Task<IBaseResponse<DiscountOnOrder>> GetDiscountOnOrderByName(string name);
}

