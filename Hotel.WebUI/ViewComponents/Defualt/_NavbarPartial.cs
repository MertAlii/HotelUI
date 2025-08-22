using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.Defualt;

public class _NavbarPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
