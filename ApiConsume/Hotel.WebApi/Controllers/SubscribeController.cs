using Hotel.BusinessLayer.Abstract;
using Hotel.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;
        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _subscribeService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddSubscribe(Subscribe Subscribe)
        {
            _subscribeService.TInsert(Subscribe);
            return Ok("Başarılı şekilde eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {
            var values = _subscribeService.TGetById(id);
            _subscribeService.TDelete(values);
            return Ok("Başarılı şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe Subscribe)
        {
            _subscribeService.TUpdate(Subscribe);
            return Ok("Başarılı şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSubscribeById(int id)
        {
            var values = _subscribeService.TGetById(id);
            return Ok(values);
        }
    }
}
