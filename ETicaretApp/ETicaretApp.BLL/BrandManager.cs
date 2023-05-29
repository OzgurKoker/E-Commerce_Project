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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Create(Brand brand)
        {
            _brandDal.Create(brand);
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public Brand GetById(int id)
        {
          return _brandDal.GetById(id);
        }

        public List<Brand> ListAll()
        {
           return _brandDal.ListAll();
        }

        public IQueryable<Brand> Query()
        {
            return _brandDal.Query();
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
