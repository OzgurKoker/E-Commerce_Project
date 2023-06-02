using ETicaretApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.BLL.Abstract
{
    public interface ISliderService
    {
        void Create(Slider slider);
        void Update(Slider slider);
        void Delete(Slider slider);
        Slider GetById(int id);
        List<Slider> ListAll();
        IQueryable<Slider> Query();
    }
}
