using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DtoLayer.Dtos.RoomDto
{
    public class RoomUpdateDto
    {
        [Required(ErrorMessage = "Lütfen Oda Id'sini Giriniz")]
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Lütfen Oda Numarasını Giriniz")]
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Lütfen Fiyatı Giriniz")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Lütfen Oda Başlığını Giriniz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen Yatak Sayısını Giriniz")]
        public string BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen Banyo Sayısını Giriniz")]
        public string BathCount { get; set; }
        [Required(ErrorMessage = "Lütfen Wifi Sayısını Giriniz")]
        public string WifiCount { get; set; }
        [Required(ErrorMessage = "Lütfen Açıklamayı Giriniz")]
        public string Descritpion { get; set; }
    }
}
