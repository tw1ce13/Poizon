using System.ComponentModel.DataAnnotations;

namespace Poizon.Domain.Models;

public class Sex
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
}

