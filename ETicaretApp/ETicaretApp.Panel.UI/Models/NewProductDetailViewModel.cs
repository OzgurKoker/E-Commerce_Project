using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ETicaretApp.Panel.UI.Models
{
    public class NewProductDetailViewModel
    {
        //public int Id { get; set; }
        public int ProductId { get; set; }
        public int CtgPropertyId { get; set; }
        public string CtgPropertyName{ get; set; }
        [Required(ErrorMessage = "PropertyValue alanı zorunludur")]
        public string PropertyValue { get; set; }
    }
}
