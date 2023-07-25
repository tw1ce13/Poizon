using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poizon.Domain.Helpers;
using Poizon.Domain.Models;
using Poizon.Services.Interfaces;

namespace Poizon.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IClothesService _clothesService;
    private readonly IOrderClothesService _orderClothesService;
    private readonly IUserService _userService;
    public OrderController(IClothesService clothesService, IUserService userService, IOrderService orderService, IOrderClothesService orderClothesService)
    {
        _orderClothesService = orderClothesService;
        _orderService = orderService;
        _userService = userService;
        _clothesService = clothesService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddToBasket(ClothesWithName clothesWithName)
    {
        var cloth = await _clothesService.GetById(clothesWithName.Id);
        clothesWithName.Photo = cloth.Data.Photo;
        var cartJson = HttpContext.Session.GetString("Cart");
        var cart = string.IsNullOrEmpty(cartJson) ? new List<ClothesWithName>() : JsonSerializer.Deserialize<List<ClothesWithName>>(cartJson);

        // Проверяем, есть ли уже товар с таким Id в корзине
        var existingItem = cart.FirstOrDefault(item => item.Id == clothesWithName.Id);
        if (existingItem != null)
        {
            // Если товар уже есть в корзине, увеличиваем значение Count
            existingItem.Count++;
        }
        else
        {
            // Если товара с таким Id нет в корзине, добавляем его
            clothesWithName.Count = 1;
            cart.Add(clothesWithName);
        }

        // Сохраните обновленную корзину в сеансе
        var updatedCartJson = JsonSerializer.Serialize(cart);
        HttpContext.Session.SetString("Cart", updatedCartJson);

        return RedirectToAction("ProductDetails", "Catalog", new { id = clothesWithName.Id });
    }


    [Authorize]
    public IActionResult ShowBasket()
    {
        // Получите текущую корзину из сессии
        var cartJson = HttpContext.Session.GetString("Cart");
        var cart = string.IsNullOrEmpty(cartJson) ? new List<ClothesWithName>() : JsonSerializer.Deserialize<List<ClothesWithName>>(cartJson);

        // Передайте список корзины в представление
        return PartialView("_ShowBasketPartial", cart);
    }

}

