using ETicaretApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.BLL.Abstract
{
    public interface ICategoryService
    {
        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);
        Category GetById(int id);
        List<Category> ListAll();

    }
}
