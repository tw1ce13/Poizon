using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poizon.Domain.Models;

public class Order
{
	public int Id { get; set; }
	[Required]
	public int UserId { get; set; }
	[ForeignKey("UserId")]
	public User? User { get; set; }
	public int DiscountId { get; set; }
	[ForeignKey("DiscountId")]
	public DiscountOnOrder? DiscountOnOrder { get; set; }
	public int Price { get; set; }
}

