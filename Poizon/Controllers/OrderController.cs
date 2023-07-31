using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Poizon.Domain.Helpers;
using Poizon.Domain.ViewModel;
using Poizon.Services.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Poizon.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IClothesService _clothesService;
    private readonly IOrderClothesService _orderClothesService;
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;
    private readonly ITelegramBotClient _telegramBot;
    public OrderController(IConfiguration configuration, IClothesService clothesService, IUserService userService, IOrderService orderService, IOrderClothesService orderClothesService)
    {
        _configuration = configuration;
        _orderClothesService = orderClothesService;
        _orderService = orderService;
        _userService = userService;
        _clothesService = clothesService;
        _telegramBot = new TelegramBotClient(_configuration["TelegramBotToken"]);
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

    [Authorize]
    [HttpPost]
    public IActionResult RemoveFromBasket(long id)
    {
        var cartJson = HttpContext.Session.GetString("Cart");
        var cart = string.IsNullOrEmpty(cartJson) ? new List<ClothesWithName>() : JsonSerializer.Deserialize<List<ClothesWithName>>(cartJson);

        // Находим товар с заданным Id в корзине и удаляем его
        var itemToRemove = cart.FirstOrDefault(item => item.Id == id);
        if (itemToRemove != null)
        {
            cart.Remove(itemToRemove);
        }

        // Сохраняем обновленную корзину в сессии
        var updatedCartJson = JsonSerializer.Serialize(cart);
        HttpContext.Session.SetString("Cart", updatedCartJson);

        return PartialView("_ShowBasketPartial", cart); // Возвращаем успешный результат запроса
    }

    [HttpGet]
    public IActionResult MakeOrder(int price)
    {
        ViewBag.Price = price;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> MakeOrder(UserViewModel userViewModel)
    {
        var s = FormatTelegramMessage(userViewModel).ToString();
        await _telegramBot.SendTextMessageAsync("950000237", s, parseMode: ParseMode.Html);

        return View("Commit");
    }


    private StringBuilder FormatTelegramMessage(UserViewModel userViewModel)
    {
        var cartJson = HttpContext.Session.GetString("Cart");
        var cart = string.IsNullOrEmpty(cartJson) ? new List<ClothesWithName>() : JsonSerializer.Deserialize<List<ClothesWithName>>(cartJson);
        var builder = new StringBuilder();
        foreach(var item in cart)
        {
            builder.Append($@"Название: {item.SubSubCategoryName}
Бренд: {item.BrandName}
Модель: {item.ModelName}
Количество: {item.Count}
Размер: {item.SizeName}
Одежда: {item.SexName}
Стиль: {item.StyleName}

");

        }
        builder.Append($@"Номер телефона: {userViewModel.PhoneNumber}
Ник в телеграм: {userViewModel.TelegramName}
Ссылка на ВК: {userViewModel.Vk}
Адрес доставки: {userViewModel.Address}
Комментарий к заказу: {userViewModel.Comment}
Итоговая стоимость: {userViewModel.Price}");
        return builder;
    }
}

