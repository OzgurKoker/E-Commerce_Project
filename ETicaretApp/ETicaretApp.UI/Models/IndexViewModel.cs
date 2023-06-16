using ETicaretApp.Entities;

namespace ETicaretApp.UI.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductImage> ProductImages { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }

    }
}
