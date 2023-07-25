using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poizon.Domain.Models;

public class SubSubCategory
{
    public long Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public long SubCategoryId { get; set; }
    [ForeignKey("SubCategoryId")]
    public SubCategory SubCategory { get; set; }
}

