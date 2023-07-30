using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poizon.Domain.Models;

public class Order
{
	public long Id { get; set; }
	[Required]
	public long UserId { get; set; }
	[ForeignKey("UserId")]
	public User? User { get; set; }
	public long DiscountId { get; set; }
	[ForeignKey("DiscountId")]
	public Discounts? Discounts { get; set; }
	public long PromocodeId { get; set; }
	[ForeignKey("PromocodeId")]
	public Promocode Promocodes { get; set; }
	public int Price { get; set; }
}

