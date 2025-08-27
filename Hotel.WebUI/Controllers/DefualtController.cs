using Hotel.WebUI.Dtos.ServiceDtos;
using Hotel.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hotel.WebUI.Controllers;
public class DefualtController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DefualtController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public PartialViewResult _SubscribePartial()
    {
        return PartialView();
    }
    [HttpPost]
    public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(model);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7020/api/Subscribe", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(model);
    }
}
