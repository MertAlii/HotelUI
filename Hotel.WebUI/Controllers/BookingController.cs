using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new CreateBookingDto { Status = "Onay Bekliyor" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBooking(CreateBookingDto createBookingDto, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(createBookingDto.Status))
                createBookingDto.Status = "Onay Bekliyor";

            if (!ModelState.IsValid)
                return View("Index", createBookingDto);

            try
            {
                var client = _httpClientFactory.CreateClient("Api");
                var response = await client.PostAsJsonAsync("Booking", createBookingDto, cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    TempData["BookingSuccess"] = "Rezervasyon talebiniz alındı.";
                    return RedirectToAction(nameof(Index));
                }

                var body = await response.Content.ReadAsStringAsync(cancellationToken);
                ModelState.AddModelError(string.Empty, $"API hatası: {(int)response.StatusCode} {response.ReasonPhrase}");
                ModelState.AddModelError(string.Empty, body);
                return View("Index", createBookingDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Beklenmeyen hata: {ex.Message}");
                return View("Index", createBookingDto);
            }
        }
    }
}