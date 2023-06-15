using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ETicaretApp.UI.Models
{
    public class RecoverPasswordViewModel
    {
        [Required(ErrorMessage = "Şifre alanı boş geçilemez.")]
        [MinLength(6, ErrorMessage = "Şifre alanı Min 6 karakter olabilir.")]
        [MaxLength(32, ErrorMessage = "Şifre alanı Maks 32 karakter olabilir.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Tekrar Şifre alanı boş geçilemez.")]
        [MaxLength(32, ErrorMessage = "Tekrar Şifre alanı Maks 32 karakter olabilir.")]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }
    }
}
