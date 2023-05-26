using ETicaretApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.BLL.Abstract
{
    public interface ICategoryPropertyService
    {
        void Create(CategoryProperty categoryProperty);
        void Update(CategoryProperty categoryProperty);
        void Delete(CategoryProperty categoryProperty);
        CategoryProperty GetById(int id);
        List<CategoryProperty> ListAll();
        IQueryable<CategoryProperty> Query();
    }
}
