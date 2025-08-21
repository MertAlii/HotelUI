using Hotel.WebUI.Dtos.StaffDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hotel.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Staff");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultStaffDto>>(json);
                return View(values ?? new List<ResultStaffDto>());
            }

            TempData["ErrorMessage"] = "Personel listesi alınamadı.";
            return View(new List<ResultStaffDto>());
        }

        [HttpGet]
        public IActionResult AddStaff() => View();

        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffDto model)
        {
            if (!ModelState.IsValid) return View(model);

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7020/api/Staff", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Personel eklendi.";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Personel eklenemedi.";
            return View(model);
        }

        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            // API uses querystring for delete: [HttpDelete] without route template
            var response = await client.DeleteAsync($"https://localhost:7020/api/Staff?id={id}");

            if (response.IsSuccessStatusCode)
                TempData["SuccessMessage"] = "Personel silindi.";
            else
                TempData["ErrorMessage"] = "Personel silinemedi.";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7020/api/Staff/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateStaffDto>(json);
                return View(value);
            }

            TempData["ErrorMessage"] = "Personel bilgisi alınamadı.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffDto model)
        {
            if (!ModelState.IsValid) return View(model);

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7020/api/Staff", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Personel güncellendi.";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Personel güncellenemedi.";
            return View(model);
        }
    }
}
