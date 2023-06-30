using System.ComponentModel.DataAnnotations;

namespace Poizon.Domain.Models;

public class SubCategory
{
	public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
}

