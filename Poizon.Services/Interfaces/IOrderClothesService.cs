using Poizon.Domain.Models;
using Poizon.Domain.Response;

namespace Poizon.Services.Interfaces;

public interface IOrderClothesService : IBaseService<OrderClothes>
{
    Task<IBaseResponse<OrderClothes>> GetOrderClothesByOrderId(long orderId);
    Task<IBaseResponse<OrderClothes>> GetOrderClothesByClothesId(long clothesId);
}

