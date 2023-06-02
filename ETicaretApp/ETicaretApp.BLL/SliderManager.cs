using ETicaretApp.BLL.Abstract;
using ETicaretApp.DAL.Abstract;
using ETicaretApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.BLL
{
    public class SliderManager : ISliderService
    {
        ISliderDal _sliderDal;
        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void Create(Slider slider)
        {
            _sliderDal.Create(slider);
        }

        public void Delete(Slider slider)
        {
            _sliderDal.Delete(slider);
        }

        public Slider GetById(int id)
        {
          return _sliderDal.GetById(id);
        }

        public List<Slider> ListAll()
        {
           return _sliderDal.ListAll();
        }

        public IQueryable<Slider> Query()
        {
            return _sliderDal.Query();
        }

        public void Update(Slider slider)
        {
            _sliderDal.Update(slider);
        }
    }
}
