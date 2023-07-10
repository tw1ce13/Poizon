namespace Poizon.Domain.Helpers;

public class ClothesWithName
{
    public long Id { get; set; }
    public string BrandName { get; set; }
    public string CategoryName { get; set; }
    public string ModelName { get; set; }
    public string SexName { get; set; }
    public string StyleName { get; set; }
    public string SubCategoryName { get; set; }
    public string? SubSubCategoryName { get; set; }
    public int Price { get; set; }
    public byte[] Photo { get; set; }

}

