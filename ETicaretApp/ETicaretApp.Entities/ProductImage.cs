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
    [Table("ProductImages")]
    public class ProductImage:EntityBase
    {
        [DisplayName("Fotoğraf")]
        [Required(ErrorMessage = "Fotoğraf boş geçilemez")]
        public string Name { get; set; }


        [DisplayName("Vitrin Fotoğrafı mı?")]
        [Required(ErrorMessage = "Vitrin fotoğrafı boş geçilemez")]
        public bool IsShowcaseImage { get; set; }


        [Required(ErrorMessage = "Sıra boş geçilemez")]
        public int Queue { get; set; }


        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
