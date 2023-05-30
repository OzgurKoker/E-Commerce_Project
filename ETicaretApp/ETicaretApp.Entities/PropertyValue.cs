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
    [Table("PropertyValues")]
    public class PropertyValue:EntityBase
    {
        [Required(ErrorMessage = "Değer boş geçilemez")]
        [DisplayName("Değer")]
        [MaxLength(50, ErrorMessage = "Değer alanı 50 karakterden fazla olamaz.")]
        public string Value { get; set; }


        public int ProductId { get; set; }
        public virtual Product Product { get; set; }


        public int CategoryPropertyId { get; set; }
        public virtual CategoryProperty CategoryProperty { get; set; }


    }
}
