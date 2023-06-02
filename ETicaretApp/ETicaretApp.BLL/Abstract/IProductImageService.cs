using ETicaretApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.BLL.Abstract
{
    public interface IProductImageService
    {
        void Create(ProductImage productImage);
        void Update(ProductImage productImage);
        void Delete(ProductImage productImage);
        ProductImage GetById(int id);
        List<ProductImage> ListAll();
        IQueryable<ProductImage> Query();
    }
}
