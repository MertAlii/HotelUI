using System.ComponentModel.DataAnnotations;

namespace Hotel.WebUI.Dtos.ServiceDtos
{
    public class UpdateServiceDto
    {
        [Required(ErrorMessage = "Servis id giriniz")]
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "Servis ikon linkini giriniz")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Servis başlığını giriniz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Servis açıklaması giriniz")]
        public string Description { get; set; }
    }
}
