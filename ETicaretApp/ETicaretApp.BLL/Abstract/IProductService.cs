using ETicaretApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.BLL.Abstract
{
    public interface IProductService
    {
        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);
        Product GetById(int id);
        List<Product> ListAll();
        IQueryable<Product> Query();
    }
}
