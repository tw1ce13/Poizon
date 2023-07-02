using System.ComponentModel.DataAnnotations;

namespace Poizon.Domain.Models;

public class Sex
{
    public long Id { get; set; }
    [Required]
    public string? Name { get; set; }
}

