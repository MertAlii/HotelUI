using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult _AdminLayout()
        {
            return View();
        }
    }
}
