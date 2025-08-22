using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.Default;

public class _TeamPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
