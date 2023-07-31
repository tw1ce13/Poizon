using Microsoft.AspNetCore.Mvc;

namespace Poizon.Controllers;

public class InfoController : Controller
{
    public IActionResult Index() => View();
}

