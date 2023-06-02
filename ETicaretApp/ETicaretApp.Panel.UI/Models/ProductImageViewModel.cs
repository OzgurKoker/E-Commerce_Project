using ETicaretApp.Entities;
using ETicaretApp.Entities.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ETicaretApp.Panel.UI.Models
{
    public class ProductImageViewModel
    {

        [DisplayName("Vitrin Fotoğrafı mı?")]
        public bool IsShowcaseImage { get; set; }
        public int ProductId { get; set; }

    }
}
