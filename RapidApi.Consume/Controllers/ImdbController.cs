using Hotel.Consume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Hotel.Consume.Controllers;
public class ImdbController : Controller
{
    public async Task<IActionResult> Index()
    {
        List<ApiMovieImdbViewModel> apiMovieImdbViewModels = new List<ApiMovieImdbViewModel>();
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
            Headers =
    {
        { "x-rapidapi-key", "0016d71d35msh16036b545e22b6ap10ed2fjsn50730392bc19" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            apiMovieImdbViewModels = JsonConvert.DeserializeObject<List<ApiMovieImdbViewModel>>(body);
            return View(apiMovieImdbViewModels);
        }
    }
}
