using ETicaretApp.BLL;
using ETicaretApp.DAL.EntityFramework;
using ETicaretApp.Panel.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ETicaretApp.Panel.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductRepository());
        BrandManager brandManager=new BrandManager(new EfBrandRepository());
        MemberManager memberManager=new MemberManager(new EfMemberRepository());
        public IActionResult Index()
        {

            var model = new DashboardViewModel() {

                Products = productManager.ListAll(),
                Brands = brandManager.ListAll(),
                Members=memberManager.ListAll(),
            };
            return View(model);
        }

      
    }
}