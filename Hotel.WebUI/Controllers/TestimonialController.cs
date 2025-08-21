using Hotel.WebUI.Dtos.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hotel.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7020/api/Testimonial");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                    return View(values ?? new List<ResultTestimonialDto>());
                }
                return View(new List<ResultTestimonialDto>());
            }
            catch
            {
                return View(new List<ResultTestimonialDto>());
            }
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial(AddTestimonialDto model)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7020/api/Testimonial", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Referans eklendi.";
                    return RedirectToAction("Index");
                }
                TempData["ErrorMessage"] = "Referans eklenemedi.";
            }
            catch
            {
                TempData["ErrorMessage"] = "Referans eklenirken bir hata oluştu.";
                ModelState.AddModelError("", "Bir hata oluştu. Lütfen tekrar deneyin.");
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync($"https://localhost:7020/api/Testimonial?id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Referans silindi.";
                    return RedirectToAction("Index");
                }
                TempData["ErrorMessage"] = "Referans silinemedi.";
            }
            catch
            {
                TempData["ErrorMessage"] = "Referans silinirken bir hata oluştu.";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"https://localhost:7020/api/Testimonial/{id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);
                    return View(values);
                }
                TempData["ErrorMessage"] = "Referans bilgisi alınamadı.";
            }
            catch
            {
                TempData["ErrorMessage"] = "Referans bilgisi alınırken bir hata oluştu.";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto model)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7020/api/Testimonial", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Referans güncellendi.";
                    return RedirectToAction("Index");
                }
                TempData["ErrorMessage"] = "Referans güncellenemedi.";
            }
            catch
            {
                TempData["ErrorMessage"] = "Referans güncellenirken bir hata oluştu.";
                ModelState.AddModelError("", "Bir hata oluştu. Lütfen tekrar deneyin.");
            }
            return View(model);
        }
    }
}
