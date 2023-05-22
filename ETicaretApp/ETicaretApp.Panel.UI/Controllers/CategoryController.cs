using ETicaretApp.BLL;
using ETicaretApp.DAL.EntityFramework;
using ETicaretApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ETicaretApp.Panel.UI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());


        public IActionResult Index()
        {
            List<Category> categoryList =  categoryManager.ListAll();
            return View(categoryList);
        }
        public IActionResult CreateCategoryPartial()
        {
            ViewBag.Category = new SelectList(categoryManager.ListAll(), "Id", "Name");
            return PartialView("_CreateCategoryPartialView");
        }
    }
}
