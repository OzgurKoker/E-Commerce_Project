using ETicaretApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.BLL.Abstract
{
    public interface IBrandService
    {
        void Create(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);
        Brand GetById(int id);
        List<Brand> ListAll();
        IQueryable<Brand> Query();
    }
}
