using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.Controllers;
public class DefualtController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
