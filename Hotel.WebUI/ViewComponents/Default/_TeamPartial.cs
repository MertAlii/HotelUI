using Hotel.WebUI.Dtos.StaffDtos;
using Hotel.WebUI.Dtos.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.WebUI.ViewComponents.Default;

public class _TeamPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _TeamPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7020/api/Staff");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultStaffDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
