using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ETicaretApp.Entities.Abstract;

namespace ETicaretApp.Panel.UI.Models
{
    public class SliderViewModel:EntityBase
    {


        [DisplayName("Küçük Başlık")]
        [MaxLength(50, ErrorMessage = "Başlık 50 karakterden fazla olamaz")]
        [Required(ErrorMessage = "Küçük başlık boş geçilemez")]
        public string SmallTittle { get; set; }


        [DisplayName("Ana Başlık")]
        [MaxLength(20, ErrorMessage = "Başlık 20 karakterden fazla olamaz")]
        [Required(ErrorMessage = "Ana başlık boş geçilemez")]
        public string MainTittle { get; set; }


        [DisplayName("Buton Url")]
        [Required(ErrorMessage = "Url alanı boş geçilemez")]
        public string Url { get; set; }
    }
}
