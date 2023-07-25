using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Poizon.Domain.ViewModel;
using Poizon.Services.Interfaces;
using Poizon.Domain.Models;

namespace Poizon.Controllers;

public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    private readonly IUserInfoService _usersInfoService;
    private readonly IUserService _userService;
    public AccountController(IUserService userService, IUserInfoService usersInfoService, IAccountService accountService)
    {
        _accountService = accountService;
        _usersInfoService = usersInfoService;
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Login() => PartialView("_LoginPartial");

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            var user = await _accountService.Login(loginViewModel);
            if (user.StatusCode == Domain.Enums.StatusCode.OK)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(user.Data));

                return RedirectToAction("Index", "Main");
            }
            ModelState.AddModelError("", user.Description);
        }
        return View("Register");
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        if (ModelState.IsValid)
        {
            var user = await _accountService.Register(registerViewModel);
            if (user.StatusCode == Domain.Enums.StatusCode.OK)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(user.Data));

                return RedirectToAction("Index", "Main");
            }
            ModelState.AddModelError("", user.Description);
        }
        return View(registerViewModel);
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Main");
    }

    [HttpGet]
    public async Task<IActionResult> ShowUserInfo()
    {
        var user = await _userService.GetUserByEmail(User.Identity.Name);
        var userInfo = await _usersInfoService.GetUserInfoByUserId(user.Data.Id);
        if (userInfo.Data == null)
        {
            var info = new UserInfo()
            {
                Name = "Заполните",
                Surname = "Заполните",
                UserId = user.Data.Id
            };
            return View(info);

        }
        return View(userInfo.Data);
    }

    [HttpPost]
    public async Task<IActionResult> ApplyChanges(UserInfo userInfo)
    {
        var baseResponse = await _usersInfoService.GetChanges(userInfo);
        return View("ShowUserInfo", baseResponse.Data);
    }

    [HttpGet]
    public async Task<IActionResult> ChangePassword()
    {
        var user = await _userService.GetUserByEmail(User.Identity.Name);
        var userInfo = await _usersInfoService.GetUserInfoByUserId(user.Data.Id);
        ViewBag.UserInfo = userInfo.Data;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        var user = await _userService.GetUserByEmail(User.Identity.Name);
        var userInfo = await _usersInfoService.GetUserInfoByUserId(user.Data.Id);
        ViewBag.UserInfo = userInfo.Data;
        if (ModelState.IsValid)
        {
            var baseResponse = await _accountService.ChangePassword(model);

            if (baseResponse != null)
            {
                ViewBag.Description = baseResponse.Description;
            }
            else
            {
                ViewBag.Description = "Ошибка: нулевой ответ от сервиса.";
            }

            return View();
        }

        ViewBag.Description = "Ошибка";
        return View();
    }
}