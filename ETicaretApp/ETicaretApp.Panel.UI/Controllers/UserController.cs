using ETicaretApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApp.Panel.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateUserPartial()
        {
            return PartialView("_CreateUserPartialView", new User());
        }
    }
}
