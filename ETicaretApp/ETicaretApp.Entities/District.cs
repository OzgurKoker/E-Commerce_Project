using ETicaretApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.Entities
{
    public class District : EntityBase
    {
        public string Name { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

    }
}
