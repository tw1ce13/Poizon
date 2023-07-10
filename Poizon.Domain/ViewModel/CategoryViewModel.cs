using Poizon.Domain.Models;

namespace Poizon.Domain.ViewModel;

public class CategoryViewModel
{
    public List<Category> Categories { get; set; }
    public Dictionary<long, List<SubCategory>> SubcategoriesByCategoryId { get; set; }
    public Dictionary<long, List<SubSubCategory>> SubSubcategoriesBySubcategoryId { get; set; }
}

