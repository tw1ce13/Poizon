using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poizon.Domain.Models;

public class Model
{
    public long Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public long BrandId { get; set; }
    [ForeignKey("BrandId")]
    public Brand Brand { get; set; }
}

