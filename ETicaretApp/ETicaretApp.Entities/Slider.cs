using ETicaretApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.Entities
{
    [Table("Sliders")]
    public class Slider:EntityBase
    {
        [DisplayName("Fotoğraf")]
        [Required(ErrorMessage = "Fotoğraf alanı boş geçilemez")]
        public string Image { get; set; }


        [Required(ErrorMessage = "Sıra boş geçilemez")]
        public int Queue { get; set; }


        [DisplayName("Küçük Başlık")]
        [MaxLength(50,ErrorMessage ="Başlık 50 karakterden fazla olamaz")]
        [Required(ErrorMessage = "Küçük başlık boş geçilemez")]
        public string SmallTittle{ get; set; }


        [DisplayName("Ana Başlık")]
        [MaxLength(20, ErrorMessage = "Başlık 20 karakterden fazla olamaz")]
        [Required(ErrorMessage = "Ana başlık boş geçilemez")]
        public string MainTittle { get; set; }


        [DisplayName("Buton Url")]
        [Required(ErrorMessage = "Url alanı boş geçilemez")]
        public string Url { get; set; }     

    }
}
