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
        private readonly ILogger<HomeController> _logger;
        CategoryManager categoryManager=new CategoryManager(new EfCategoryRepository());
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
          List<Category> categories= categoryManager.ListAll();
           return View(categories);
        }

        public IActionResult Shop()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}