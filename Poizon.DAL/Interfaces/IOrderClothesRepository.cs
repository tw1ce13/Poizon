using Poizon.Domain.Models;

namespace Poizon.DAL.Interfaces;

public interface IOrderClothesRepository : IBaseRepository<OrderClothes>
{
    Task<OrderClothes> GetOrderClothesByOrderId(long orderId);
    Task<OrderClothes> GetOrderClothesByClothesId(long clothesId);
}
