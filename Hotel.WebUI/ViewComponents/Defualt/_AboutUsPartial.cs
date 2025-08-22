using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.Defualt;

public class _AboutUsPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
