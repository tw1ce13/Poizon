using System.ComponentModel.DataAnnotations;

namespace Poizon.Domain.Models;

public class Model
{
    public long Id { get; set; }
    [Required]
    public string? Name { get; set; }
}

