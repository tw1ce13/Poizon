using System.ComponentModel.DataAnnotations;

namespace Poizon.Domain.Models;

public class DiscountOnOrder
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public int Value { get; set; }
    public int Count { get; set; }
}

