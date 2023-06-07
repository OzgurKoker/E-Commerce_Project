using ETicaretApp.BLL;
using ETicaretApp.DAL.EntityFramework;
using ETicaretApp.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApp.UI.Controllers
{
    public class ShopController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index()
        {
            var model = new IndexViewModel()
            {
                Categories = categoryManager.ListAll()
            };
            return View(model);
        }
    }
}
