using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poizon.Domain.Models;

public class SubCategory
{
	public long Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public long CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
}

