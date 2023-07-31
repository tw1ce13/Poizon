using Poizon.Domain.Helpers;

namespace Poizon.Domain.ViewModel;

public class BasketViewModel
{
    public ClothesWithName ClothesWithName { get; set; }
    public int Count { get; set; }
    public int UserId { get; set; }
    public int Price { get; set; }
    public int DiscountId { get; set; }
    public int PromocodeId { get; set; }
}

