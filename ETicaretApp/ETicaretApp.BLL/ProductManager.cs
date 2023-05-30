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
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Create(Product product)
        {
            _productDal.Create(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public Product GetById(int id)
        {
          return _productDal.GetById(id);
        }

        public List<Product> ListAll()
        {
           return _productDal.ListAll();
        }

        public IQueryable<Product> Query()
        {
            return _productDal.Query();
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
