using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poizon.Domain.Models;

public class Availability
{
    public int Id { get; set; }
    [Required]
    public int ClothesId { get; set; }
    [ForeignKey("ClothesId")]
    public Clothes? Clothes { get; set; }
    public int Count { get; set; }
}

