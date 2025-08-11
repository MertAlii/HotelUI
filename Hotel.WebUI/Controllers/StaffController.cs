using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
