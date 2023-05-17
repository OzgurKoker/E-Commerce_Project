using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.BLL.Abstract
{
    public interface IProductService
    {
        Product GetProductDetails(int id);
        ProductListWM GetAll();
        List<Product> GetPopularMethod();
        ProductListWM GetProductsByCategory(string category);
        Product GetById(int id);
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
    }
}
