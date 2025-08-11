using Hotel.BusinessLayer.Abstract;
using Hotel.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _serviceService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddService(Service Service)
        {
            _serviceService.TInsert(Service);
            return Ok("Başarılı şekilde eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var values = _serviceService.TGetById(id);
            _serviceService.TDelete(values);
            return Ok("Başarılı şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateService(Service Service)
        {
            _serviceService.TUpdate(Service);
            return Ok("Başarılı şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetServiceById(int id)
        {
            var values = _serviceService.TGetById(id);
            return Ok(values);
        }
    }
}
