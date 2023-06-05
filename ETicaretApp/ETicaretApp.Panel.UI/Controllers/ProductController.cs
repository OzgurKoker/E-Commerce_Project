using ETicaretApp.BLL;
using ETicaretApp.DAL.EntityFramework;
using ETicaretApp.Entities;
using ETicaretApp.Panel.UI.Models;
using ETicaretApp.Panel.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace ETicaretApp.Panel.UI.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        BrandManager brandManager = new BrandManager(new EfBrandRepository());
        CategoryPropertyManager categoryPropertyManager = new CategoryPropertyManager(new EfCategoryPropertyRepository());
        ProductImageManager ProductImageManager = new ProductImageManager(new EfProductImageRepository());
        PropertyValueManager propertyValueManager = new PropertyValueManager(new EfPropertyValueRepository());
        private readonly INotificationService notificationService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(INotificationService notificationService, IWebHostEnvironment webHostEnvironment)
        {
            this.notificationService = notificationService;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            //List<Product> productList = productManager.ListAll();
            var listele = productManager.Query().Include(x => x.Category).Include(x => x.Brand);
            return View(listele);
        }


        public IActionResult CreateProductPartial()
        {
            ViewBag.Category = new SelectList(categoryManager.ListAll().Where(x => x.CategoryId != null), "Id", "Name");
            ViewBag.Brand = new SelectList(brandManager.ListAll(), "Id", "Name");

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
                        Price = product.Price,
                        DiscountedPrice = product.DiscountedPrice,
                        StockQuantity = product.StockQuantity,
                        IsShowcaseProduct = product.IsShowcaseProduct,
                        IsNewProduct = product.IsNewProduct,
                        BrandId = product.BrandId,
                        CategoryId = product.CategoryId
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

            List<NewProductDetailViewModel> newProductDetailViewModels = new List<NewProductDetailViewModel>();


            Product product = productManager.GetById(id);
            List<CategoryProperty> properties = categoryPropertyManager.ListAll().Where(x => x.CategoryId == product.CategoryId).ToList();

            foreach (CategoryProperty property in properties)
            {
                string value = "";
                if (propertyValueManager.ListAll().Any(x => x.ProductId == product.Id && x.CategoryPropertyId == property.Id))
                {
                    value = propertyValueManager.ListAll().FirstOrDefault(x => x.ProductId == product.Id && x.CategoryPropertyId == property.Id).Value;
                }
                newProductDetailViewModels.Add(new NewProductDetailViewModel
                {
                    CtgPropertyId = property.Id,
                    CtgPropertyName = property.Property,
                    ProductId = product.Id,
                    PropertyValue = value
                });

            }

            return PartialView("_DetailProductPartialView", newProductDetailViewModels);



        }

        [HttpPost]
        public IActionResult CreateDetail(List<NewProductDetailViewModel> productDetailViewModels)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in productDetailViewModels)
                {
                    if (propertyValueManager.ListAll().Any(x => x.ProductId == item.ProductId && x.CategoryPropertyId == item.CtgPropertyId))
                    {
                        propertyValueManager.Update(new PropertyValue
                        {
                            Value = item.PropertyValue,
                            ProductId = item.ProductId,
                            CategoryPropertyId = item.CtgPropertyId
                        });
                    }
                    else
                    {
                        propertyValueManager.Create(new PropertyValue
                        {
                            Value = item.PropertyValue,
                            ProductId = item.ProductId,
                            CategoryPropertyId = item.CtgPropertyId
                        });
                    }
                }
            }
            else
            {
                notificationService.Notification(NotifyType.Error, "Tüm alanları doldurmak zorunludur");
                return BadRequest();
            }
            return Ok();
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
        public IActionResult ImageProductPartial(int id)
        {
            ProductImageViewModel productImage = new ProductImageViewModel()
            {
                ProductId = id,
            };
            return PartialView("_ImageProductPartialView", productImage);
        }
        [HttpPost]
        public IActionResult CreateImage(IFormFile photo, ProductImageViewModel productImage)
        {
            try
            {
                if (photo != null)
                {
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
                    string fileExtension = Path.GetExtension(photo.FileName).ToLower();

                    if (allowedExtensions.Contains(fileExtension))
                    {
                        int fileSizeLimit = 10 * 1024 * 1024;

                        if (photo.Length <= fileSizeLimit)
                        {
                            string wwwrootPath = webHostEnvironment.WebRootPath;
                            string fileName = Path.GetFileNameWithoutExtension(photo.FileName);
                            string extension = Path.GetExtension(photo.FileName);

                            string newFileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                            string path = Path.Combine(wwwrootPath + "/img/Product/", newFileName);

                            List<ProductImage> productImageList = ProductImageManager.ListAll().Where(x => x.ProductId == productImage.ProductId).ToList();

                            //vitrin fotografı olarak sectiyse db'ye bakıyor daha önce o ürüne vitrin fotosu atanmış mı diye
                            if (productImage.IsShowcaseImage)
                            {
                                foreach (var item in productImageList)
                                {
                                    if (item.IsShowcaseImage)
                                    {
                                        notificationService.Notification(NotifyType.Error, "Bu ürüne daha önce vitrin fotoğrafı atanmış");
                                        return RedirectToAction(nameof(Index));
                                    }
                                }
                            }

                            using (var fileStream = new FileStream(path, FileMode.Create))
                            {
                                photo.CopyTo(fileStream);
                            }

                            ProductImageManager.Create(new ProductImage()
                            {
                                Image = newFileName,
                                IsShowcaseImage = productImage.IsShowcaseImage,
                                ProductId = productImage.ProductId,
                            });
                            notificationService.Notification(NotifyType.Success, "Başarıyla fotoğraf eklendi.");

                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            notificationService.Notification(NotifyType.Error, "Dosya boyutu limiti aşıldı (10mb)");
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else
                    {
                        notificationService.Notification(NotifyType.Error, "Geçersiz Dosya Formatı (jpg,jpeg,png) Seçiniz.");
                        return RedirectToAction(nameof(Index));

                    }
                }
                else
                {
                    notificationService.Notification(NotifyType.Error, "Fotoğraf Seçimi Zorunludur.");

                }
            }
            catch (Exception ex)
            {

                notificationService.Notification(NotifyType.Error, ex.Message);

            }


            return RedirectToAction(nameof(Index));

        }
    }
}
