using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApp.UI.Controllers
{
    [Authorize]
    public class AddressController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
