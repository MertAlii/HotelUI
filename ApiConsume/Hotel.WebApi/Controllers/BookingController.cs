using Hotel.BusinessLayer.Abstract;
using Hotel.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;
    public BookingController(IBookingService BookingService)
    {
        _bookingService = BookingService;
    }

    [HttpGet]
    public IActionResult BookingList()
    {
        var values = _bookingService.TGetList();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult AddBooking(Booking booking)
    {
        _bookingService.TInsert(booking);
        return Ok("Başarılı şekilde eklendi");
    }

    [HttpDelete]
    public IActionResult DeleteBooking(int id)
    {
        var values = _bookingService.TGetById(id);
        _bookingService.TDelete(values);
        return Ok("Başarılı şekilde silindi");
    }

    [HttpPut]
    public IActionResult UpdateBooking(Booking booking)
    {
        _bookingService.TUpdate(booking);
        return Ok("Başarılı şekilde güncellendi");
    }

    [HttpGet("{id}")]
    public IActionResult GetBookingById(int id)
    {
        var values = _bookingService.TGetById(id);
        return Ok(values);
    }
}
