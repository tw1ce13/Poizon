using System.ComponentModel.DataAnnotations;

namespace Poizon.Domain.Models;

public class Style
{
    public long Id { get; set; }
    [Required]
    public string? Name { get; set; }
}

