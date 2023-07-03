using Microsoft.AspNetCore.Mvc;
namespace Poizon.Controllers;

public class MainController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
