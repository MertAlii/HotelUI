using Hotel.WebUI.Dtos.ServiceDtos;
using Hotel.WebUI.Dtos.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.WebUI.ViewComponents.Default;

public class _TrailerPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
