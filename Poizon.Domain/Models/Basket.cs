using System.ComponentModel.DataAnnotations.Schema;

namespace Poizon.Domain.Models;

public class Basket
{
    public int Id { get; set; }
    public int ClothId { get; set; }
    [ForeignKey("ClothId")]
    public Cloth? Cloth { get; set; }
    public int Count { get; set; }
}