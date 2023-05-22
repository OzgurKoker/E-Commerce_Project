using ETicaretApp.BLL;
using ETicaretApp.DAL.EntityFramework;
using ETicaretApp.Panel.UI.Models;
using ETicaretApp.Panel.UI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ETicaretApp.Panel.UI.Controllers
{
    public class AuthController : Controller
    {
        UserManager userManager = new UserManager(new EfUserRepository());


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = userManager.ListAll().FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            if (user != null && user.State)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Role,user.Role)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));


                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı bilgileri hatalı");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı aktif değil");
                }
            }

            return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Auth");
        }
       
    }
}
