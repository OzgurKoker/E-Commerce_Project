using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApp.Panel.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CompanyInformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
