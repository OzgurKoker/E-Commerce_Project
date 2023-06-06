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
    [Table("Products")]
    public class Product:EntityBase
    {
        [Required(ErrorMessage ="Ürün Adı Alanı Boş Geçilemez.")]
        [MaxLength(100,ErrorMessage = "Ürün adı alanı 100 karakterden fazla olamaz.")]
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Ürün Açıklama Alanı Boş Geçilemez.")]
        [MaxLength(3000,ErrorMessage = "Ürün açıklama alanı 3000 karakterden fazla olamaz.")]
        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Fiyat Alanı Boş Geçilemez.")]
        [DisplayName("Ürün Fiyatı")]
        public double? Price { get; set; }



        [DisplayName("İndirimli Fiyat")]
        public double? DiscountedPrice { get; set; }


        [Required(ErrorMessage ="Stok Alanı Boş Geçilemez.")]
        [DisplayName("Ürün Stok")]
        public int StockQuantity { get; set; }


        [DisplayName("Vitrin Ürünü mü?")]
        [Required(ErrorMessage = "Vitrin Ürünü Alanı Boş Geçilemez.")]
        public bool IsShowcaseProduct { get; set; }


        [DisplayName("Yeni Ürün mü?")]
        [Required(ErrorMessage = "Yeni Ürün Alanı Boş Geçilemez.")]
        public bool IsNewProduct { get; set; }

        [DisplayName("Marka")]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        [DisplayName("Kategori")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<PropertyValue> PropertyValues  { get; set; }
    }
}
