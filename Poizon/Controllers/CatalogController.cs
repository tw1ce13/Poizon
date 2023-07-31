using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Poizon.Domain.Helpers;
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
    public async Task<JsonResult> GetSubcategoriesByName(string name)
    {
        var baseResponseCategory = await _categoryService.GetCategoryByName(name);
        var baseResponse = await _subCategoryService.GetAll();
        var subCategories = baseResponse.Data.Where(x => x.CategoryId == baseResponseCategory.Data.Id);

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

    [HttpGet]
    public async Task<IActionResult> AddClothes()
    {
        var baseResponseCategory = await _categoryService.GetAll();
        var baseResponseSex = await _sexService.GetAll();
        ViewBag.Sex = baseResponseSex.Data; 
        ViewBag.Category = baseResponseCategory.Data;
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> AddClothes(ClothesWithName clothes, IFormFile photo, IFormFile photo1, IFormFile photo2,
        IFormFile photo3, IFormFile photo4, IFormFile photo5)
    {
        MakePhoto(clothes, photo, photo1, photo2, photo3, photo4, photo5);
        var baseResponse = await _clothesService.AddClothesByAdmin(clothes);
        return RedirectToAction("ProductDetails", new { id = baseResponse.Data.Id });
    }

    [HttpPost]
    public async Task<IActionResult> RewriteClothes(ClothesWithName clothesWithName)
    {
        var baseResponse = await _categoryService.GetAll();
        ViewBag.Category = baseResponse.Data;
        return View(clothesWithName);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateClothes(ClothesWithName clothesWithName, IFormFile photo, IFormFile photo1, IFormFile photo2,
        IFormFile photo3, IFormFile photo4, IFormFile photo5)
    {
        MakePhoto(clothesWithName, photo, photo1, photo2, photo3, photo4, photo5);
        var baseResponse = await _clothesService.UpdateClothesByAdmin(clothesWithName);
        return RedirectToAction("ProductDetails", new { id = baseResponse.Data.Id });
    }


    private void MakePhoto(ClothesWithName clothes, IFormFile photo, IFormFile photo1, IFormFile photo2,
        IFormFile photo3, IFormFile photo4, IFormFile photo5)
    {
        if (photo != null)
        {
            using (var memoryStream = new MemoryStream())
            {
                photo.CopyTo(memoryStream);
                clothes.Photo = memoryStream.ToArray();
            }
        }

        if (photo1 != null)
        {
            using (var memoryStream = new MemoryStream())
            {
                photo1.CopyTo(memoryStream);
                clothes.Photo1 = memoryStream.ToArray();
            }
        }

        if (photo2 != null)
        {
            using (var memoryStream = new MemoryStream())
            {
                photo2.CopyTo(memoryStream);
                clothes.Photo2 = memoryStream.ToArray();
            }
        }

        if (photo3 != null)
        {
            using (var memoryStream = new MemoryStream())
            {
                photo3.CopyTo(memoryStream);
                clothes.Photo3 = memoryStream.ToArray();
            }
        }

        if (photo4 != null)
        {
            using (var memoryStream = new MemoryStream())
            {
                photo4.CopyTo(memoryStream);
                clothes.Photo4 = memoryStream.ToArray();
            }
        }

        if (photo5 != null)
        {
            using (var memoryStream = new MemoryStream())
            {
                photo5.CopyTo(memoryStream);
                clothes.Photo5 = memoryStream.ToArray();
            }
        }
    }
}
