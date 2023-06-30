using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poizon.Domain.Models;

public class OrderClothes
{
    public int Id { get; set; }
    [Required]
    public int OrderId { get; set; }
    [ForeignKey("OrderId")]
    public Order? Order { get; set; }
    public int ClothesId { get; set; }
    [ForeignKey("ClothesId")]
    public Clothes? Clothes { get; set; }
}

