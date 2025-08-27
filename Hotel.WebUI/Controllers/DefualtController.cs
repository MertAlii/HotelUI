using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.Controllers;
public class DefualtController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public PartialViewResult _SubscribePartial()
    {
        return PartialView();
    }
}
