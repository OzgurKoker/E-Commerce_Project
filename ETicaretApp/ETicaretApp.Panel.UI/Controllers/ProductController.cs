using ETicaretApp.BLL;
using ETicaretApp.DAL.EntityFramework;
using ETicaretApp.Entities;
using ETicaretApp.Panel.UI.Models;
using ETicaretApp.Panel.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApp.Panel.UI.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        BrandManager brandManager = new BrandManager(new EfBrandRepository());
        CategoryPropertyManager categoryPropertyManager = new CategoryPropertyManager(new EfCategoryPropertyRepository());
        private readonly INotificationService notificationService;

        public ProductController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public IActionResult Index()
        {
            //List<Product> productList = productManager.ListAll();
            var listele = productManager.Query().Include(x=>x.Category).Include(x=>x.Brand);
            return View(listele);
        }


        public IActionResult CreateProductPartial()
        {
            ViewBag.Category = new SelectList(categoryManager.ListAll().Where(x => x.CategoryId != null), "Id", "Name");
            ViewBag.Brand = new SelectList(brandManager.ListAll(), "Id","Name");

            return PartialView("_CreateProductPartialView");
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel product)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    productManager.Create(new Product()
                    {
                     Name = product.Name,
                     Description = product.Description,
                     Price=product.Price,
                     DiscountedPrice=product.DiscountedPrice,
                     StockQuantity=product.StockQuantity,
                     IsShowcaseProduct=product.IsShowcaseProduct,
                     IsNewProduct=product.IsNewProduct,
                     BrandId=product.BrandId,
                     CategoryId=product.CategoryId
                    });
                    notificationService.Notification(NotifyType.Success, $"{product.Name} İsimli Ürün Başarılı Bir Şekilde Oluşturuldu");
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

        public IActionResult DetailProductPartial(int id)
        {
           Product product= productManager.GetById(id);
           List<CategoryProperty> properties = categoryPropertyManager.ListAll().Where(x=>x.CategoryId==product.CategoryId).ToList();
            return PartialView("_DetailProductPartialView",properties);
        }

        [HttpPost]
        public IActionResult CreateDetail(PropertyValue propertyValue)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpPost] 
        public IActionResult updateShowCaseState(int id)
        {
            var product = productManager.GetById(id);
            product.IsShowcaseProduct = !product.IsShowcaseProduct;
            productManager.Update(product);
            notificationService.Notification(NotifyType.Success, $"{product.Name} ürün güncellendi.");

            return Ok("Kullanıcı durumu güncellendi..");
        }
        [HttpPost] 
        public IActionResult updateNewProductState(int id)
        {
            var product = productManager.GetById(id);
            product.IsNewProduct = !product.IsNewProduct;
            productManager.Update(product);
            notificationService.Notification(NotifyType.Success, $"{product.Name} ürün güncellendi.");

            return Ok("Kullanıcı durumu güncellendi..");
        }
    }

}
