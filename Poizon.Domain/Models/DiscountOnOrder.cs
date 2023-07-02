using System.ComponentModel.DataAnnotations;

namespace Poizon.Domain.Models;

public class DiscountOnOrder
{
    public long Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public int Value { get; set; }
    public int Count { get; set; }
}

