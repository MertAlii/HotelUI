using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.Defualt;

public class _ReservationPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
