using ETicaretApp.DAL.Abstract;
using ETicaretApp.DAL.Repositories;
using ETicaretApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.DAL.EntityFramework
{
    public class EfProductImageRepository:GenericRepository<ProductImage>,IProductImageDal
    {
    }
}
