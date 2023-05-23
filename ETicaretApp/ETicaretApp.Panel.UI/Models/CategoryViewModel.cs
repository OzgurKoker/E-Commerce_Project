using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ETicaretApp.Panel.UI.Models
{
    public class CategoryViewModel
    {
        [DisplayName("Kategori Adı")]
        [MaxLength(50, ErrorMessage = "Kategori adı alanı 50 karakterden fazla olamaz.")]
        [Required(ErrorMessage = "Kategori adı alanı boş geçilemez")]
        public string Name { get; set; }

        [DisplayName("Ana Kategori")]
        public int? CategoryId { get; set; }

        public bool check { get; set; }
    }
}
