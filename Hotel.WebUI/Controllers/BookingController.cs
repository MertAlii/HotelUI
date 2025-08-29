using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.Controllers;
public class BookingController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
