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
    public class CategoryPropertyController : Controller
    {
        CategoryPropertyManager categoryPropertyManager = new CategoryPropertyManager(new EfCategoryPropertyRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        private readonly INotificationService notificationService;
        public CategoryPropertyController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }
        public IActionResult Index()
        {
            ViewBag.Category = new SelectList(categoryManager.ListAll().Where(x => x.CategoryId != null), "Id", "Name");

            List<CategoryProperty> categoryProperties = categoryPropertyManager.ListAll();
            return View(categoryProperties);
        }


        public IActionResult CreateCategoryPropertyPartial()
        {
            ViewBag.Category = new SelectList(categoryManager.ListAll().Where(x => x.CategoryId != null), "Id", "Name");

            return PartialView("_CreateCategoryPropertyPartialView");
        }
        [HttpPost]
        public IActionResult Create(CategoryProperty categoryProperty)
        {
       
            if (ModelState.IsValid)
            {
                try
                {
                    categoryPropertyManager.Create(categoryProperty);
                    notificationService.Notification(NotifyType.Success, $"{categoryProperty.Property} İsimli Kategori özelliği Başarılı Bir Şekilde Oluşturuldu");
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
        public IActionResult EditCategoryPropertyPartial(int id)
        {
            CategoryProperty categoryProperty = categoryPropertyManager.GetById(id);
            return PartialView("_EditCategoryPropertyPartialView", categoryProperty);
        }
        [HttpPost]
        public IActionResult Edit(CategoryProperty categoryProperty)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    categoryPropertyManager.Update(categoryProperty);
                    notificationService.Notification(NotifyType.Success, $"{categoryProperty.Property} İsimli Kategori özelliği Başarılı Bir Şekilde Güncellendi");
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
        public IActionResult DeleteCategoryPropertyPartial(int id)
        {
            CategoryProperty ctgProperty= categoryPropertyManager.GetById(id);
            return PartialView("_DeleteCategoryPropertyPartialView",ctgProperty);
        }
        [HttpPost]
        public IActionResult Delete(CategoryProperty categoryProperty)
        {

            try
            {
                categoryPropertyManager.Delete(categoryProperty);
                notificationService.Notification(NotifyType.Success, $"{categoryProperty.Property} İsimli Kategori özelliği silindi.");
            }
            catch (Exception ex)
            {

                notificationService.Notification(NotifyType.Error, ex.Message);
            }


            return RedirectToAction(nameof(Index));
        }
   
    
    }
}
