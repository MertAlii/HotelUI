using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.Default;

public class _ServicePartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
