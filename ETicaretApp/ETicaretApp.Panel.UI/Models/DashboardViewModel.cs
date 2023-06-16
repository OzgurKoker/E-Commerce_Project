using ETicaretApp.Entities;

namespace ETicaretApp.Panel.UI.Models
{
    public class DashboardViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Member> Members { get; set; }
    }
}
