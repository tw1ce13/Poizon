using System.ComponentModel.DataAnnotations.Schema;

namespace Poizon.Domain.Models;

public class Order
{
    public int Id { get; set; }
    public int BasketId { get; set; }
    [ForeignKey("BasketId")]
    public Basket? Basket { get; set; }
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User? User { get; set; }

}