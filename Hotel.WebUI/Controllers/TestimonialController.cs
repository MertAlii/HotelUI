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
                else
                {
                    // API çağrısı başarısız, boş liste döndür
                    return View(new List<ResultTestimonialDto>());
                }
            }
            catch (Exception)
            {
                // Hata durumunda boş liste döndür
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
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
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
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                // Hata durumunda index'e yönlendir
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
            }
            catch (Exception)
            {
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
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Bir hata oluştu. Lütfen tekrar deneyin.");
            }
            return View(model);
        }
    }
}
