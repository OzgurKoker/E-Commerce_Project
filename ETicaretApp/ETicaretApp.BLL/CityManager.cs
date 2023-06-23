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
    public class CityManager : ICityService
    {
        ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public void Create(City city)
        {
            _cityDal.Create(city);
        }

        public void Delete(City city)
        {
            _cityDal.Delete(city);
        }

        public City GetById(int id)
        {
          return _cityDal.GetById(id);
        }

        public List<City> ListAll()
        {
           return _cityDal.ListAll();
        }

        public IQueryable<City> Query()
        {
            return _cityDal.Query();
        }

        public void Update(City city)
        {
            _cityDal.Update(city);
        }
    }
}
