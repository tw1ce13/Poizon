using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poizon.Domain.Models;

public class OrderClothes
{
    public long Id { get; set; }
    [Required]
    public long OrderId { get; set; }
    [ForeignKey("OrderId")]
    public Order? Order { get; set; }
    public long ClothesId { get; set; }
    [ForeignKey("ClothesId")]
    public Clothes? Clothes { get; set; }
}

