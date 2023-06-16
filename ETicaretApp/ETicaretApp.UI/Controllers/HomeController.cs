using ETicaretApp.BLL;
using ETicaretApp.DAL.EntityFramework;
using ETicaretApp.Entities;
using ETicaretApp.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ETicaretApp.UI.Controllers
{
    public class HomeController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        ProductManager productManager= new ProductManager(new EfProductRepository());
        ProductImageManager productImageManager= new ProductImageManager(new EfProductImageRepository());
        SliderManager sliderManager=new SliderManager(new EfSliderRepository());
    

        public IActionResult Index()
        {
            var model = new IndexViewModel()
            {
                Categories = categoryManager.ListAll(),
                Products = productManager.Query().Include(x => x.Brand).Where(x => x.State == true).OrderByDescending(x => x.CreatedDate).Take(8),
                ProductImages =productImageManager.ListAll(),
                Sliders=sliderManager.ListAll()
            };
            return View(model);
        }



   
    }
}