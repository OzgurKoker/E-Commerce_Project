using ETicaretApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.Entities
{
    [Table("Cities")]
    public class City:EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<District> Districts { get; set; }

    }
}
