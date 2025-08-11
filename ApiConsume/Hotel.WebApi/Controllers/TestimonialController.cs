using Hotel.BusinessLayer.Abstract;
using Hotel.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddTestimonial(Testimonial Testimonial)
        {
            _testimonialService.TInsert(Testimonial);
            return Ok("Başarılı şekilde eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetById(id);
            _testimonialService.TDelete(values);
            return Ok("Başarılı şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial Testimonial)
        {
            _testimonialService.TUpdate(Testimonial);
            return Ok("Başarılı şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonialById(int id)
        {
            var values = _testimonialService.TGetById(id);
            return Ok(values);
        }
    }
}
