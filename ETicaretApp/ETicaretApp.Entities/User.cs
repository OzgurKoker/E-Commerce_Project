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
    [Table("Users")]
    public class User:EntityBase
    {
        public DateTime RegisterDate { get; set; } = DateTime.Now;

        [DisplayName("Email")]
        [Required(ErrorMessage ="Email alanı boş geçilemez.")]
        [MaxLength(50,ErrorMessage ="Email alanı 50 karakterden fazla olamaz.")]
        public string Email { get; set; }


        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Şifre alanı boş geçilemez.")]
        [MaxLength(50, ErrorMessage = "Şifre alanı 50 karakterden fazla olamaz.")]
        public string Password { get; set; }


        [DisplayName("Durum")]
        public bool State { get; set; }


        [DisplayName("Yetki")]
        public string Role { get; set; }



    }
}
