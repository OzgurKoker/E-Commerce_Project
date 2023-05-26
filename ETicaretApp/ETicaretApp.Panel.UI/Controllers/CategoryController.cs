using ETicaretApp.BLL;
using ETicaretApp.DAL.EntityFramework;
using ETicaretApp.Entities;
using ETicaretApp.Panel.UI.Models;
using ETicaretApp.Panel.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ETicaretApp.Panel.UI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        private readonly INotificationService notificationService;
        public CategoryController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public IActionResult Index()
        {
            List<Category> categoryList = categoryManager.ListAll();
            return View(categoryList);
        }
        public IActionResult CreateCategoryPartial()
        {
            ViewBag.Category = new SelectList(categoryManager.ListAll().Where(x => x.CategoryId == null), "Id", "Name");
            return PartialView("_CreateCategoryPartialView");
        }
        [HttpPost]
        public IActionResult Create(CategoryViewModel ctgView)
        {
            if (ctgView.check)
                ctgView.CategoryId = null;



            if (ModelState.IsValid)
            {
                try
                {
                    categoryManager.Create(new Category { Name = ctgView.Name, CategoryId = ctgView.CategoryId });
                    notificationService.Notification(NotifyType.Success, $"{ctgView.Name} İsimli Kategori Başarılı Bir Şekilde Oluşturuldu");
                }
                catch (Exception ex)
                {
                    notificationService.Notification(NotifyType.Error, ex.Message);
                }
            }
            else
                ModelStateControl.KontrolEt(notificationService, ModelState);




            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditCategoryPartial(int id)
        {
            Category category = categoryManager.GetById(id);
            return PartialView("_EditCategoryPartialView", category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {


                try
                {
                    categoryManager.Update(category);
                    notificationService.Notification(NotifyType.Success, $"{category.Name} Mail adresli kullanıcı güncellendi.");
                }
                catch (Exception ex)
                {

                    notificationService.Notification(NotifyType.Error, ex.Message);
                }
            }
            else
                ModelStateControl.KontrolEt(notificationService, ModelState);


            return RedirectToAction(nameof(Index));
        }
    }
}
