using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProject.WebUI.Dtos.BookingDto
{
    public class CreateBookingDto
    {
        [Required(ErrorMessage = "Ad Soyad zorunlu.")]
        public string Name { get; set; } = null!;

        [Required, EmailAddress(ErrorMessage = "Geçerli bir mail giriniz.")]
        public string Mail { get; set; } = null!;

        [Required(ErrorMessage = "Giriş tarihi zorunlu.")]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = "Çıkış tarihi zorunlu.")]
        public DateTime CheckOut { get; set; }

        [Required]
        public string AdultCount { get; set; } = "1";

        [Required]
        public string ChildCount { get; set; } = "0";

        [Required]
        public string RoomCount { get; set; } = "1";

        public string? SpecialRequest { get; set; }

        [Column("Desription")]
        public string? Description { get; set; }

        public string Status { get; set; } = "Onay Bekliyor";
    }
}