using ETicaretApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.BLL.Abstract
{
    public interface ICityService
    {
        void Create(City city);
        void Update(City city);
        void Delete(City city);
        City GetById(int id);
        List<City> ListAll();
        IQueryable<City> Query();
    }
}
