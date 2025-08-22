using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.Default;

public class _ScriptsPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
