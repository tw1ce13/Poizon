using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poizon.Domain.Models;

public class Clothes
{
    public long Id { get; set; }

    [Required]
    public long CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }

    [Required]
    public long SubCategoryId { get; set; }
    [ForeignKey("SubCategoryId")]
    public SubCategory? SubCategory { get; set; }

    [Required]
    public long BrandId { get; set; }
    [ForeignKey("BrandId")]
    public Brand? Brand { get; set; }

    [Required]
    public long ModelId { get; set; }
    [ForeignKey("ModelId")]
    public Model? Model { get; set; }

    [Required]
    public long SizeId { get; set; }
    [ForeignKey("SizeId")]
    public Size? Size { get; set; }

    [Required]
    public long StyleId { get; set; }
    [ForeignKey("StyleId")]
    public Style? Style { get; set; }

    [Required]
    public long SexId { get; set; }
    [ForeignKey("SexId")]
    public Sex? Sex { get; set; }

    [Required]
    public byte[]? Photo { get; set; }
    public string? Description { get; set; }
    [Required]
    public int Cost { get; set; }

}

