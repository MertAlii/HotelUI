using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.Controllers;
public class RoomController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
