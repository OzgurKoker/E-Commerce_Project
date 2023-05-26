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
    public class CategoryPropertyManager : ICategoryPropertyService
    {
        ICategoryPropertyDal _categoryPropertyDal;
        public CategoryPropertyManager(ICategoryPropertyDal categoryDal)
        {
            _categoryPropertyDal = categoryDal;
        }

        public void Create(CategoryProperty categoryProperty)
        {
            _categoryPropertyDal.Create(categoryProperty);
        }

        public void Delete(CategoryProperty categoryProperty)
        {
            _categoryPropertyDal.Delete(categoryProperty);
        }

        public CategoryProperty GetById(int id)
        {
          return _categoryPropertyDal.GetById(id);
        }

        public List<CategoryProperty> ListAll()
        {
           return _categoryPropertyDal.ListAll();
        }

        public IQueryable<CategoryProperty> Query()
        {
            return _categoryPropertyDal.Query();
        }

        public void Update(CategoryProperty categoryProperty)
        {
            _categoryPropertyDal.Update(categoryProperty);
        }
    }
}
