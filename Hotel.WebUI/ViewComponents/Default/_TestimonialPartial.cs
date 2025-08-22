using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.Default;

public class _TestimonialPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
