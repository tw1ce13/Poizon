using Microsoft.AspNetCore.Mvc;
namespace Poizon.Controllers;

public class CatalogController : Controller
{
    public IActionResult ShowAll()
    {
        return View();
    }
}

