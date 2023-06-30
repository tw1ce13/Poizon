using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poizon.Domain.Models;

public class Clothes
{
    public int Id { get; set; }

    [Required]
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }

    [Required]
    public int SubCategoryId { get; set; }
    [ForeignKey("SubCategoryId")]
    public SubCategory? SubCategory { get; set; }

    [Required]
    public int BrandId { get; set; }
    [ForeignKey("BrandId")]
    public Brand? Brand { get; set; }

    [Required]
    public int ModelId { get; set; }
    [ForeignKey("ModelId")]
    public Model? Model { get; set; }

    [Required]
    public int SizeId { get; set; }
    [ForeignKey("SizeId")]
    public Size? Size { get; set; }

    [Required]
    public int StyleId { get; set; }
    [ForeignKey("StyleId")]
    public Style? Style { get; set; }

    [Required]
    public int SexId { get; set; }
    [ForeignKey("SexId")]
    public Sex? Sex { get; set; }

    [Required]
    public byte[]? Photo { get; set; }
    public string? Description { get; set; }
    [Required]
    public int Cost { get; set; }

}

