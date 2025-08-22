using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.Default;

public class _TrailerPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
