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
    [Table("Brands")]
    public class Brand:EntityBase
    {
        [DisplayName("Marka adı")]
        [Required(ErrorMessage ="Marka adı alanı boş geçilemez.")]
        [MaxLength(50, ErrorMessage = "Marka adı alanı 50 karakterden fazla olamaz.")]
        public string Name { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
