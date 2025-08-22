using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.Defualt;

public class _HeadPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
