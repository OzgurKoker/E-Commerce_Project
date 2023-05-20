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
                var dbuser = userManager.ListAll().FirstOrDefault(x => x.Email == user.Email);

                if (dbuser != null)
                {
                    notificationService.Notification(NotifyType.Error, "Email adresini baska bir kullanıcı kullanıyor");
                    return RedirectToAction(nameof(Index));
                }


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

                //Yapılacak

                //var dbuser = userManager.ListAll().FirstOrDefault(x => x.Email == user.Email && x.Id!=user.Id);

                //if (dbuser != null)
                //{
                //    notificationService.Notification(NotifyType.Error, "Email adresini baska bir kullanıcı kullanıyor");
                //    return RedirectToAction(nameof(Index));
                //}


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

        [HttpPost]
        public IActionResult UpdateUserState(int id)
        {
            var user = userManager.GetById(id);
            user.State = !user.State;
            userManager.Update(user);
            notificationService.Notification(NotifyType.Success, $"{user.Email} Mail adresli kullanıcı güncellendi.");

            return Ok("Kullanıcı durumu güncellendi..");
        }




    }
}
