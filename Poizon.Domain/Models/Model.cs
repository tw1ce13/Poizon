using System.ComponentModel.DataAnnotations;

namespace Poizon.Domain.Models;

public class Model
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
}

