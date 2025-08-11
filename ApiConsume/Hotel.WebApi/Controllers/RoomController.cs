using Hotel.BusinessLayer.Abstract;
using Hotel.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddRoom(Room Room)
        {
            _roomService.TInsert(Room);
            return Ok("Başarılı şekilde eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            var values = _roomService.TGetById(id);
            _roomService.TDelete(values);
            return Ok("Başarılı şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateRoom(Room Room)
        {
            _roomService.TUpdate(Room);
            return Ok("Başarılı şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetRoomById(int id)
        {
            var values = _roomService.TGetById(id);
            return Ok(values);
        }
    }
}