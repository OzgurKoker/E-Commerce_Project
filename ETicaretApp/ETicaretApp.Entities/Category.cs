using ETicaretApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.Entities
{
    [Table("Categories")]
    public class Category:EntityBase
    {
        [DisplayName("Kategori Adı")]
        [MaxLength(50,ErrorMessage ="Kategori adı alanı 50 karakterden fazla olamaz.")]
        [Required(ErrorMessage = "Kategori adı alanı boş geçilemez")]
        public string Name { get; set; }

        public int? CategoryId { get; set; }


        public virtual ICollection<CategoryProperty>? CategoryProperties { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
