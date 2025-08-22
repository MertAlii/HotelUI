using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.Default;

public class _FooterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
