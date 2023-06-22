using ETicaretApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.Entities
{
    [Table("CompanyInformation")]
    public class CompanyInformation:EntityBase
    {
        [DisplayName("Site adı")]
        [Required(ErrorMessage = "Site adı alanı boş geçilemez.")]
        [MaxLength(150, ErrorMessage = "Site adı alanı 150 karakterden fazla olamaz.")]
        public string Title { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Açıklama alanı boş geçilemez.")]
        [MaxLength(300, ErrorMessage = "Açıklama alanı 300 karakterden fazla olamaz.")]
        public string Comment { get; set; }

        [DisplayName("Adres")]
        [Required(ErrorMessage = "Adres alanı boş geçilemez.")]
        [MaxLength(150, ErrorMessage = "Adres alanı 150 karakterden fazla olamaz.")]
        public string Address { get; set; }

        [DisplayName("E-Mail")]
        [Required(ErrorMessage = "E-Mail alanı boş geçilemez.")]
        [MaxLength(50, ErrorMessage = "E-Mail alanı 50 karakterden fazla olamaz.")]
        public string Mail { get; set; }

        [DisplayName("İletişim Numarası")]
        [Required(ErrorMessage = "İletişim Numarası alanı boş geçilemez.")]
        [MaxLength(20, ErrorMessage = "İletişim Numarası alanı 20 karakterden fazla olamaz.")]
        public string PhoneNumber { get; set; }

        [DisplayName("Facebook")]
        public string? Facebook { get; set; }

        [DisplayName("Twitter")]
        public string? Twitter { get; set; }

        [DisplayName("Linkedin")]
        public string? Linkedin { get; set; }

        [DisplayName("Instagram")]
        public string? Instagram { get; set; }

        [DisplayName("Youtube")]
        public string? Youtube { get; set; }
    }
}
