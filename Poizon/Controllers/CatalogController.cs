using Microsoft.AspNetCore.Mvc;
using Poizon.Domain.Models;
using Poizon.Domain.ViewModel;
using Poizon.Services.Interfaces;

namespace Poizon.Controllers;

public class CatalogController : Controller
{
    private readonly IClothesService _clothesService;
    private readonly ICategoryService _categoryService;
    private readonly ISubCategoryService _subCategoryService;
    private readonly ISubSubCategoryService _subSubCategoryService;

    public CatalogController(ISubSubCategoryService subSubCategoryService, IClothesService clothesService, ICategoryService categoryService, ISubCategoryService subCategoryService)
    {
        _clothesService = clothesService;
        _categoryService = categoryService;
        _subCategoryService = subCategoryService;
        _subSubCategoryService = subSubCategoryService;
    }

    public async Task<IActionResult> ShowAll()
    {
        var clothes = await _clothesService.GetAllWithName();
        var categories = await _categoryService.GetAll();
        var subcategories = await _subCategoryService.GetAll();
        var subsubcategories = await _subSubCategoryService.GetAll();
        var viewModel = new CategoryViewModel
        {
            Categories = categories.Data.ToList(),
            SubcategoriesByCategoryId = GroupSubcategoriesByCategoryId(subcategories.Data.ToList()),
            SubSubcategoriesBySubcategoryId = GroupSubsubcategoriesBySubcategoryId(subsubcategories.Data.ToList())
        };
        ViewBag.ViewModel = viewModel;
        ViewBag.Data = clothes.Data;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ShowWithFilters(CatalogFilters model)
    {
        if (ModelState.IsValid)
        {
            var clothes = await _clothesService.GetAllByFilters(model);
            return View(clothes.Data);
        }
        return BadRequest();
    }
    private Dictionary<long, List<SubSubCategory>> GroupSubsubcategoriesBySubcategoryId(List<SubSubCategory> subsubcategories)
    {
        var groupedSubsubcategories = new Dictionary<long, List<SubSubCategory>>();

        foreach (var subsubcategory in subsubcategories)
        {
            if (!groupedSubsubcategories.ContainsKey(subsubcategory.SubCategoryId))
            {
                groupedSubsubcategories[subsubcategory.SubCategoryId] = new List<SubSubCategory>();
            }

            groupedSubsubcategories[subsubcategory.SubCategoryId].Add(subsubcategory);
        }

        return groupedSubsubcategories;
    }
    private Dictionary<long, List<SubCategory>> GroupSubcategoriesByCategoryId(List<SubCategory> subcategories)
    {
        var groupedSubcategories = new Dictionary<long, List<SubCategory>>();

        foreach (var subcategory in subcategories)
        {
            if (!groupedSubcategories.ContainsKey(subcategory.CategoryId))
            {
                groupedSubcategories[subcategory.CategoryId] = new List<SubCategory>();
            }

            groupedSubcategories[subcategory.CategoryId].Add(subcategory);
        }

        return groupedSubcategories;
    }

}

