using System.ComponentModel.DataAnnotations;

namespace Hotel.WebUI.Dtos.AppUserDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage = "Adınızı giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyadınızı giriniz")]
        public string  Surname { get; set; }
        [Required(ErrorMessage = "Kullanıcı adınızı giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "E-posta adresinizi giriniz")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Şifrenizi giriniz")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifrenizi tekrar giriniz")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor")]
        public string ConfirmPassword { get; set; }
    }
}
