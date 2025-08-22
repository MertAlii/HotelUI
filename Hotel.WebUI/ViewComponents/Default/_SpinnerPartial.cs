using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.Defualt;

public class _SpinnerPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
