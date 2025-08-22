using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.Defualt;

public class _SliderPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
