using System.ComponentModel.DataAnnotations;

namespace ETicaretApp.UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email alanı boş geçilemez")]
        [MaxLength(50,ErrorMessage ="Email maks 50 karakter olabilir.")]
        public string Email { get; set; }


        [Required(ErrorMessage ="Şifre alanı boş geçilemez.")]
        [MinLength(6,ErrorMessage ="Şifre alanı Min 6 karakter olabilir.")]
        [MaxLength(32,ErrorMessage ="Şifre alanı Maks 32 karakter olabilir.")]
        public string Password { get; set; }
    }
}
