using ETicaretApp.BLL;
using ETicaretApp.DAL.EntityFramework;
using ETicaretApp.Entities;
using ETicaretApp.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ETicaretApp.UI.Controllers
{
    public class HomeController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        ProductManager productManager= new ProductManager(new EfProductRepository());
    

        public IActionResult Index()
        {
            var model = new IndexViewModel()
            {
                Categories = categoryManager.ListAll(),
                Products = productManager.ListAll().Where(x=>x.State==true).OrderByDescending(x=>x.CreatedDate).Take(8)
            };
            return View(model);
        }



   
    }
}