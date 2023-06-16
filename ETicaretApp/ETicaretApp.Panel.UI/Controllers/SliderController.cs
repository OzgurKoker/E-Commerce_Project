using ETicaretApp.BLL;
using ETicaretApp.DAL.EntityFramework;
using ETicaretApp.Entities;
using ETicaretApp.Panel.UI.Models;
using ETicaretApp.Panel.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApp.Panel.UI.Controllers
{
    [Authorize]
    public class SliderController : Controller
    {
        SliderManager sliderManager = new SliderManager(new EfSliderRepository());
        private readonly INotificationService notificationService;
        private readonly IWebHostEnvironment webHostEnvironment;
        public SliderController(INotificationService notificationService, IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.notificationService = notificationService;
        }


        public IActionResult Index()
        {
            List<Slider> sliderList = sliderManager.ListAll();
            return View(sliderList);
        }

        public IActionResult CreateSliderPartial()
        {
            return PartialView("_CreateSliderPartialView");
        }

        [HttpPost]
        public IActionResult Create(SliderViewModel slider, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                try
                {



                    if (photo != null)
                    {
                        string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
                        string fileExtension = Path.GetExtension(photo.FileName).ToLower();

                        if (allowedExtensions.Contains(fileExtension))
                        {
                            int fileSizeLimit = 10 * 1024 * 1024;

                            if (photo.Length <= fileSizeLimit)
                            {
                                string wwwrootPath = webHostEnvironment.WebRootPath;
                                string fileName = Path.GetFileNameWithoutExtension(photo.FileName);
                                string extension = Path.GetExtension(photo.FileName);

                                string newFileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                                string path = Path.Combine(wwwrootPath + "/img/Slider/", newFileName);

                                using (var fileStream = new FileStream(path, FileMode.Create))
                                {
                                    photo.CopyTo(fileStream);
                                }

                                sliderManager.Create(new Slider()
                                {
                                    Image = newFileName,
                                    MainTittle = slider.MainTittle,
                                    SmallTittle = slider.SmallTittle,
                                    Url = slider.Url


                                });
                                notificationService.Notification(NotifyType.Success, "Başarıyla fotoğraf eklendi.");

                                return RedirectToAction(nameof(Index));
                            }
                            else
                            {
                                notificationService.Notification(NotifyType.Error, "Dosya boyutu limiti aşıldı (10mb)");
                                return RedirectToAction(nameof(Index));
                            }
                        }
                        else
                        {
                            notificationService.Notification(NotifyType.Error, "Geçersiz Dosya Formatı (jpg,jpeg,png) Seçiniz.");
                            return RedirectToAction(nameof(Index));

                        }
                    }
                    else
                    {
                        notificationService.Notification(NotifyType.Error, "Fotoğraf Seçimi Zorunludur.");

                    }
                }
                catch (Exception ex)
                {

                    notificationService.Notification(NotifyType.Error, ex.Message);

                }
            }
            else
            {
                ModelStateControl.KontrolEt(notificationService, ModelState);

            }

            return RedirectToAction(nameof(Index));

        }

        public IActionResult DeleteSliderPartial(int id)
        {
            Slider slider = sliderManager.GetById(id);


            return PartialView("_DeleteSliderPartialView", slider);

        }
        [HttpPost]
        public IActionResult Delete(Slider slider)
        {

            try
            {
                sliderManager.Delete(slider);
                notificationService.Notification(NotifyType.Success, $"Fotoğraf silindi.");
            }
            catch (Exception ex)
            {

                notificationService.Notification(NotifyType.Error, ex.Message);
            }


            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditSliderPartial(int id)
        {
            Slider slider = sliderManager.GetById(id);
            return PartialView("_EditSliderPartialView", slider);

        }

        [HttpPost]
        public IActionResult Edit(Slider slider, IFormFile photo)
        {
         
            try
            {
                if (photo != null)
                {
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
                    string fileExtension = Path.GetExtension(photo.FileName).ToLower();

                    if (allowedExtensions.Contains(fileExtension))
                    {
                        int fileSizeLimit = 10 * 1024 * 1024;

                        if (photo.Length <= fileSizeLimit)
                        {
                            string wwwrootPath = webHostEnvironment.WebRootPath;
                            string fileName = Path.GetFileNameWithoutExtension(photo.FileName);
                            string extension = Path.GetExtension(photo.FileName);

                            string newFileName = slider.Image;
                            string path = Path.Combine(wwwrootPath + "/img/Slider/", newFileName);

                            using (var fileStream = new FileStream(path, FileMode.Create))
                            {
                                photo.CopyTo(fileStream);
                            }

                            sliderManager.Update(new Slider()
                            {
                                Id = slider.Id,
                                Image = newFileName,
                                MainTittle = slider.MainTittle,
                                SmallTittle = slider.SmallTittle,
                                Url = slider.Url


                            });
                            notificationService.Notification(NotifyType.Success, "Başarıyla fotoğraf eklendi.");

                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            notificationService.Notification(NotifyType.Error, "Dosya boyutu limiti aşıldı (10mb)");
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else
                    {
                        notificationService.Notification(NotifyType.Error, "Geçersiz Dosya Formatı (jpg,jpeg,png) Seçiniz.");
                        return RedirectToAction(nameof(Index));

                    }
                }
                else
                {
                    sliderManager.Update(new Slider()
                    {
                        Id = slider.Id,
                        Image=slider.Image,
                        MainTittle = slider.MainTittle,
                        SmallTittle = slider.SmallTittle,
                        Url = slider.Url


                    });
                    notificationService.Notification(NotifyType.Success, "Başarıyla Güncellendi.");

                }
            }
            catch (Exception ex)
            {

                notificationService.Notification(NotifyType.Error,"Alanları Boş Bırakmayınız");

            }


            return RedirectToAction(nameof(Index));

        }


    }
}
