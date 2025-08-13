using System.ComponentModel.DataAnnotations;

namespace Hotel.WebUI.Dtos.ServiceDtos
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage = "Servis ikon linkini giriniz")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Servis Başlığını giriniz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Servis açıklaması giriniz")]
        public string Description { get; set; }
    }
}
