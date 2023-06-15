using System.ComponentModel.DataAnnotations;

namespace ETicaretApp.UI.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email alanı boş geçilemez")]
        [MaxLength(50, ErrorMessage = "Email maks 50 karakter olabilir.")]
        public string Email { get; set; }
    }
}
