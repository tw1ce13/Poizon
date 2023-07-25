using Microsoft.AspNetCore.Mvc;
using Poizon.Domain.ViewModel;
using Poizon.Services.Interfaces;

namespace Poizon.Controllers;

public class CatalogController : Controller
{
    private readonly IClothesService _clothesService;
    private readonly ICategoryService _categoryService;
    private readonly ISubCategoryService _subCategoryService;
    private readonly ISubSubCategoryService _subSubCategoryService;
    private readonly IBrandService _brandService;
    private readonly IStyleService _styleService;
    private readonly ISexService _sexService;

    public CatalogController(ISexService sexService, IStyleService styleService, IBrandService brandService, ISubSubCategoryService subSubCategoryService, IClothesService clothesService, ICategoryService categoryService, ISubCategoryService subCategoryService)
    {
        _clothesService = clothesService;
        _categoryService = categoryService;
        _subCategoryService = subCategoryService;
        _subSubCategoryService = subSubCategoryService;
        _brandService = brandService;
        _sexService = sexService;
        _styleService = styleService;
    }

    public async Task<IActionResult> ShowAll()
    {
        var clothes = await _clothesService.GetAllWithName();
        var baseResponseBrand = await _brandService.GetAll();
        var baseResponseSex = await _sexService.GetAll();
        var baseResponseStyle = await _styleService.GetAll();
        var category = await _categoryService.GetAll();
        ViewBag.Category = category.Data;
        ViewBag.Brand = baseResponseBrand.Data;
        ViewBag.Sex = baseResponseSex.Data;
        ViewBag.Style = baseResponseStyle.Data;
        ViewBag.Data = clothes.Data;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ShowWithFilters([FromBody]CatalogFilters model)
    {
        if (ModelState.IsValid)
        {
            var clothes = await _clothesService.GetAllByFilters(model);
            return PartialView("_ProductListPartial", clothes.Data);
        }
        return BadRequest();
    }

    [HttpGet]
    public async Task<JsonResult> GetSubcategories(long categoryId)
    {
        var baseResponse = await _subCategoryService.GetAll();
        var subCategories = baseResponse.Data.Where(x => x.CategoryId == categoryId);

        return Json(subCategories);
    }

    [HttpGet]
    public async Task<JsonResult> GetSubSubcategories(long subCategoryId)
    {
        var baseResponse = await _subSubCategoryService.GetAll();
        var subCategories = baseResponse.Data.Where(x => x.SubCategoryId == subCategoryId);

        return Json(subCategories);
    }

    public async Task<IActionResult> ProductDetails(long id)
    {
        var product = await _clothesService.GetByIdWithName(id);
        if (product == null)
        {
            return NotFound();
        }
        var listPhoto = new List<byte[]>
        {
            product.Data.Photo,
            product.Data.Photo1,
            product.Data.Photo2,
            product.Data.Photo3,
            product.Data.Photo4,
            product.Data.Photo5,
        };
        ViewBag.Photos = listPhoto;
        return View(product.Data);
    }
}
