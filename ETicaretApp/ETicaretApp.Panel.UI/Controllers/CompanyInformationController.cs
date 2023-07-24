using ETicaretApp.BLL;
using ETicaretApp.DAL.EntityFramework;
using ETicaretApp.Entities;
using ETicaretApp.Panel.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApp.Panel.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CompanyInformationController : Controller
    {
        CompanyInformationManager companyInformationManager = new CompanyInformationManager(new EfCompanyInformationRepository());
        private readonly INotificationService notificationService;
        public CompanyInformationController(INotificationService notificationService)
        {
            
            this.notificationService = notificationService;
        }
       
        public IActionResult Index(int id)
        {
            CompanyInformation companyInformation = companyInformationManager.GetById(id);
            return View(companyInformation);
        }

        //[HttpPost]
        //public IActionResult Index(CompanyInformation companyInformation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            CompanyInformation existingCompany = companyInformationManager.GetById(companyInformation.Id);
        //            if (existingCompany != null)
        //            {
        //                existingCompany.Title = companyInformation.Title;
        //                existingCompany.Comment = companyInformation.Comment;
        //                existingCompany.Address = companyInformation.Address;
        //                existingCompany.Mail = companyInformation.Mail;
        //                existingCompany.PhoneNumber = companyInformation.PhoneNumber;
        //                existingCompany.Facebook = companyInformation.Facebook;
        //                existingCompany.Twitter = companyInformation.Twitter;
        //                existingCompany.Linkedin = companyInformation.Linkedin;
        //                existingCompany.Instagram = companyInformation.Instagram;
        //                existingCompany.Youtube = companyInformation.Youtube;

        //                companyInformationManager.Create(existingCompany);

        //                notificationService.Notification(NotifyType.Success, $"{existingCompany.Title} İsimli Şirket Bilgileri Başarılı Bir Şekilde Güncellendi");
        //            }
        //            else
        //            {

        //                notificationService.Notification(NotifyType.Error, " İsimli Şirket Bilgileri Başarılı Bir Şekilde Oluşturuldu");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            notificationService.Notification(NotifyType.Error, ex.Message);
        //        }

        //        return RedirectToAction("Index", "CompanyInformation");
        //    }
        //    else
        //    {
        //        ModelStateControl.KontrolEt(notificationService, ModelState);
        //    }

        //    return View(companyInformation);
        //}


    }
}
