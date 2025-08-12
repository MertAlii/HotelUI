using AutoMapper;
using Hotel.BusinessLayer.Abstract;
using Hotel.DtoLayer.Dtos.RoomDto;
using Hotel.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public Room2Controller(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddRoom(RoomAddDto room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(room);
            _roomService.TInsert(values);
            return Ok("Başarılı bir şekilde eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteRoom(int ıd)
        {
            var values = _roomService.TGetById(ıd);
            if (values == null)
            {
                return NotFound();
            }
            _roomService.TDelete(values);
            return Ok("Başarılı bir şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateRoom(RoomUpdateDto room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(room);
            _roomService.TUpdate(values);
            return Ok("Başarılı bir şekilde güncellendi");
        }
    }
}
