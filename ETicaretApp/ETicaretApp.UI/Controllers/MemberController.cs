using ETicaretApp.BLL;
using ETicaretApp.DAL.EntityFramework;
using ETicaretApp.Entities;
using ETicaretApp.UI.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using System.Security.Claims;

namespace ETicaretApp.UI.Controllers
{
    public class MemberController : Controller
    {
        MemberManager memberManager = new MemberManager(new EfMemberRepository());
        private readonly IConfiguration configuration;

        public MemberController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string md5Salt = configuration.GetValue<string>("AppSettings:MD5Salt");
                string saltedPassword = model.Password + md5Salt;
                string hashedPassword = saltedPassword.MD5();
                var user = memberManager.ListAll().FirstOrDefault(x => x.Email.ToLower() == model.Email.ToLower() && x.Password.ToLower() == hashedPassword.ToLower());
          
                if (user != null && user.State)
                {
                    List<Claim> claims = new List<Claim>
                    {
                     new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                     new Claim(ClaimTypes.Email,user.Email)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                    return RedirectToAction("Index","Home");
                }
                else
                {
                    if (user == null)
                    {
                        ModelState.AddModelError("", "Kullanıcı bilgileri hatalı");
                        return View(model);

                    }
                    else
                    {
                        ModelState.AddModelError("", "Kullanıcı aktif değil");
                        return View(model);

                    }
                }


            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            try
            {
                if (!model.Terms)
                    ModelState.AddModelError(nameof(model.Terms), "Şartları Kabul ediniz.");

                if (ModelState.IsValid)
                {
                    if (memberManager.Query().Any(x => x.Email.ToLower() == model.Email.ToLower()))
                    {
                        ModelState.AddModelError(nameof(model.Email), "Email kullanılıyor");
                        return View(model);

                    }

                    string md5Salt = configuration.GetValue<string>("AppSettings:MD5Salt");
                    string saltedPassword = model.Password + md5Salt;
                    string hashedPassword = saltedPassword.MD5();


                    Member member = new Member()
                    {
                        Email = model.Email,
                        Password = hashedPassword,
                        RegisterDate = DateTime.Now,
                        State = true
                    };
                    memberManager.Create(member);
                }
                else
                {
                    return View(model);
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }

            return RedirectToAction(nameof(Login));
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
