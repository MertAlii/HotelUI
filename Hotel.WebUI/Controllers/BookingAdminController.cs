using Hotel.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7020/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }

            TempData["ErrorMessage"] = $"İşlem başarısız. Kod: {(int)responseMessage.StatusCode} {responseMessage.ReasonPhrase}";
            return View(new List<ResultBookingDto>());
        }

        public async Task<IActionResult> ApprovedReservation2(int id)
        {
            var ok = await TryUpdateStatusAsync(id, "Onaylandı");
            TempData[ok ? "SuccessMessage" : "ErrorMessage"] =
                ok ? "Rezervasyon onaylandı." : "İşlem başarısız. Kod: 500 Internal Server Error";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CancelReservation(int id)
        {
            var ok = await TryUpdateStatusAsync(id, "İptal Edildi");
            TempData[ok ? "SuccessMessage" : "ErrorMessage"] =
                ok ? "Rezervasyon iptal edildi." : "İşlem başarısız. Kod: 500 Internal Server Error";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> WaitReservation(int id)
        {
            var ok = await TryUpdateStatusAsync(id, "Beklemede");
            TempData[ok ? "SuccessMessage" : "ErrorMessage"] =
                ok ? "Rezervasyon beklemeye alındı." : "İşlem başarısız. Kod: 500 Internal Server Error";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7020/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }

            TempData["ErrorMessage"] = $"İşlem başarısız. Kod: {(int)responseMessage.StatusCode} {responseMessage.ReasonPhrase}";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7020/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Rezervasyon güncellendi.";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = $"İşlem başarısız. Kod: {(int)responseMessage.StatusCode} {responseMessage.ReasonPhrase}";
            return View(updateBookingDto);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7020/api/Booking/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<UpdateBookingDto>(json);
                if (dto is null)
                {
                    TempData["ErrorMessage"] = "İşlem başarısız. Kod: 500 Internal Server Error";
                    return RedirectToAction("Index");
                }
                return View(dto);
            }

            TempData["ErrorMessage"] = $"İşlem başarısız. Kod: {(int)response.StatusCode} {response.ReasonPhrase}";
            return RedirectToAction("Index");
        }

        private async Task<bool> TryUpdateStatusAsync(int id, string status)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                var get = await client.GetAsync($"https://localhost:7020/api/Booking/{id}");
                if (!get.IsSuccessStatusCode)
                {
                    TempData["ErrorMessage"] = $"İşlem başarısız. Kod: {(int)get.StatusCode} {get.ReasonPhrase}";
                    return false;
                }

                var json = await get.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<UpdateBookingDto>(json);
                if (dto is null)
                {
                    TempData["ErrorMessage"] = "İşlem başarısız. Kod: 500 Internal Server Error";
                    return false;
                }

                dto.Status = status;
                var payload = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
                var put = await client.PutAsync("https://localhost:7020/api/Booking", payload);
                if (!put.IsSuccessStatusCode)
                {
                    TempData["ErrorMessage"] = $"İşlem başarısız. Kod: {(int)put.StatusCode} {put.ReasonPhrase}";
                    return false;
                }

                return true;
            }
            catch
            {
                TempData["ErrorMessage"] = "İşlem başarısız. Kod: 500 Internal Server Error";
                return false;
            }
        }
    }
}