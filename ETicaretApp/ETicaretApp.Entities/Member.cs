using ETicaretApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.Entities
{
    [Table("Members")]
    public class Member
    {
        [Key]
        public Guid Id { get; set; }


        [Required]
        [StringLength(50)]
        public string Email { get; set; }


        [Required]
        [StringLength(150)]
        public string Password { get; set; }

        [StringLength(50)]
        public string? FullName { get; set; }


        [Required]
        public bool State { get; set; }


        public DateTime RegisterDate { get; set; }
    }
}
