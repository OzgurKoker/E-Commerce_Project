using ETicaretApp.BLL;
using ETicaretApp.DAL.EntityFramework;
using ETicaretApp.Entities;
using ETicaretApp.Panel.UI.Models;
using ETicaretApp.Panel.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ETicaretApp.Panel.UI.Controllers
{
    [Authorize]
    public class BrandController : Controller
    {
        BrandManager brandManager = new BrandManager(new EfBrandRepository());
        private readonly INotificationService notificationService;
        public BrandController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }
        public IActionResult Index()
        {
            List<Brand> brandList= brandManager.ListAll();
            return View(brandList);
        }
        public IActionResult CreateBrandPartial()
        {
            return PartialView("_CreateBrandPartialView");
        }
        [HttpPost]
        public IActionResult Create(Brand brand)
        {
        
            if (ModelState.IsValid)
            {
                try
                {
                    brandManager.Create(brand);
                    notificationService.Notification(NotifyType.Success, $"{brand.Name} İsimli Marka Başarılı Bir Şekilde Oluşturuldu");
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
        public IActionResult DeleteBrandPartial(int id)
        {
            Brand brand = brandManager.GetById(id);


            return PartialView("_DeleteBrandPartialView", brand);

        }
        [HttpPost]
        public IActionResult Delete(Brand brand)
        {

            try
            {
                brandManager.Delete(brand);
                notificationService.Notification(NotifyType.Success, $"{brand.Name} isimli marka silindi.");
            }
            catch (Exception ex)
            {

                notificationService.Notification(NotifyType.Error, ex.Message);
            }


            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditBrandPartial(int id)
        {
            Brand brand = brandManager.GetById(id);
            return PartialView("_EditBrandPartialView", brand);

        }
        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {


                try
                {
                    brandManager.Update(brand);
                    notificationService.Notification(NotifyType.Success, $"{brand.Name} isimli marka güncellendi.");
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
