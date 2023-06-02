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
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;
        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        public void Create(ProductImage productImage)
        {
            _productImageDal.Create(productImage);
        }

        public void Delete(ProductImage productImage)
        {
            _productImageDal.Delete(productImage);
        }

        public ProductImage GetById(int id)
        {
          return _productImageDal.GetById(id);
        }

        public List<ProductImage> ListAll()
        {
           return _productImageDal.ListAll();
        }

        public IQueryable<ProductImage> Query()
        {
            return _productImageDal.Query();
        }

        public void Update(ProductImage productImage)
        {
            _productImageDal.Update(productImage);
        }
    }
}
