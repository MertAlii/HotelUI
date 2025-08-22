using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.Default;

public class _OurRoomsPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
