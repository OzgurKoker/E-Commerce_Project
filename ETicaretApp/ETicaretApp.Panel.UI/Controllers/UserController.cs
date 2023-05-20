using ETicaretApp.BLL;
using ETicaretApp.DAL.EntityFramework;
using ETicaretApp.Entities;
using ETicaretApp.Panel.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApp.Panel.UI.Controllers
{
    public class UserController : Controller
    {

        private readonly INotificationService notificationService;
        public UserController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }
        UserManager userManager = new UserManager(new EfUserRepository());
        public IActionResult Index()
        {
            List<User> userList = userManager.ListAll();
            return View(userList);

        }
        public IActionResult CreateUserPartial()
        {
            return PartialView("_CreateUserPartialView", new User());
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userManager.Create(user);
                    notificationService.Notification(NotifyType.Success, $"{user.Email} Mail adresli kullanıcı başarılı bir şekilde kayıt edildi.");
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
        public IActionResult EditUserPartial(int id)
        {
            User user = userManager.GetById(id);
            return PartialView("_EditUserPartialView", user);

        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userManager.Update(user);
                    notificationService.Notification(NotifyType.Success, $"{user.Email} Mail adresli kullanıcı güncellendi.");
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
        public IActionResult DeleteUserPartial(int id)
        {
            User user = userManager.GetById(id);


            return PartialView("_DeleteUserPartialView", user);

        }

        [HttpPost]
        public IActionResult Delete(User user)
        {

            try
            {
                userManager.Delete(user);
                notificationService.Notification(NotifyType.Success, $"{user.Email} Mail adresli kullanıcı silindi.");
            }
            catch (Exception ex)
            {

                notificationService.Notification(NotifyType.Error, ex.Message);
            }


            return RedirectToAction(nameof(Index));
        }






    }
}
