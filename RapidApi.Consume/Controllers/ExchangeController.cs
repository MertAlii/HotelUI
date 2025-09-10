using Microsoft.AspNetCore.Mvc;

namespace Hotel.Consume.Controllers;
public class ExchangeController : Controller
{
    public async Task<IActionResult> Index()
    {
        using System.Net.Http.Headers;
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/attractions/calendar?attraction_id=PRFZkGSVnM5d&currency=AED&locale=en-gb"),
            Headers =
    {
        { "x-rapidapi-key", "0016d71d35msh16036b545e22b6ap10ed2fjsn50730392bc19" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);
        }
        return View();
    }
}
