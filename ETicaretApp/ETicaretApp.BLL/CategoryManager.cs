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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Create(Category category)
        {
            _categoryDal.Create(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public Category GetById(int id)
        {
          return _categoryDal.GetById(id);
        }

        public List<Category> ListAll()
        {
           return _categoryDal.ListAll();
        }

        public IQueryable<Category> Query()
        {
            return _categoryDal.Query();
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
