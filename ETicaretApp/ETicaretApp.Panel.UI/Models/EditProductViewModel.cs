using ETicaretApp.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ETicaretApp.Panel.UI.Models
{
    public class EditProductViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürün Adı Alanı Boş Geçilemez.")]
        [MaxLength(100, ErrorMessage = "Ürün adı alanı 100 karakterden fazla olamaz.")]
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Ürün Açıklama Alanı Boş Geçilemez.")]
        [MaxLength(3000, ErrorMessage = "Ürün açıklama alanı 3000 karakterden fazla olamaz.")]
        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }


 
        [DisplayName("Ürün Fiyatı")]
        public double? Price { get; set; }



        [DisplayName("İndirimli Fiyat")]
        public double? DiscountedPrice { get; set; }


        [Required(ErrorMessage = "Stok Alanı Boş Geçilemez.")]
        [DisplayName("Ürün Stok")]
        public int StockQuantity { get; set; }


        [DisplayName("Vitrin Ürünü mü?")]
        [Required(ErrorMessage = "Vitrin Ürünü Alanı Boş Geçilemez.")]
        public bool IsShowcaseProduct { get; set; }


        [DisplayName("Yeni Ürün mü?")]
        [Required(ErrorMessage = "Yeni Ürün Alanı Boş Geçilemez.")]
        public bool IsNewProduct { get; set; }
        [DisplayName("Durum")]
        public bool State { get; set; }

        [DisplayName("Marka")]
        public int BrandId { get; set; }

        [DisplayName("Kategori")]
        public int CategoryId { get; set; }

    }
}
