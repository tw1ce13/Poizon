using Microsoft.AspNetCore.Mvc;
namespace Poizon.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
