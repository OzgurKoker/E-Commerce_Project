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
    [Table("CategoryProperties")]
    public class CategoryProperty : EntityBase
    {
        [DisplayName("Özellik Adı")]
        [MaxLength(50, ErrorMessage = "Özellik adı alanı 50 karakterden fazla olamaz.")]
        public string? Property { get; set; }

        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}