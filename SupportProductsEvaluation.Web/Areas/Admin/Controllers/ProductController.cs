using Microsoft.AspNetCore.Mvc;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using SupportProductsEvaluation.Infrastructure.VMs;
using System.IO;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IShopService _shopService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        public ProductController(IProductService productService, IShopService shopService, ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _productService = productService;
            _shopService = shopService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
            => View(await _productService.GetAllHeaders());

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.IsExist = false;

            ProductCreateEditVM productCreateEditVMError = new ProductCreateEditVM()
            {
                Product = new Product(),
                CategoryList = await _categoryService.GetAll(),
                ShopList = await _shopService.GetAllDetails()
            };

            return View(productCreateEditVMError);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateEditVM productCreateEditVM)
        {

            if (!ModelState.IsValid)
            {
                ProductCreateEditVM productCreateEditVMError = new ProductCreateEditVM()
                {
                    Product=productCreateEditVM.Product,
                    CategoryList = await _categoryService.GetAll(),
                    ShopList = await _shopService.GetAllDetails()
                };

                return View(productCreateEditVMError);
            }

            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0)
            {
                byte[] p1 = null;
                using (var fs1 = files[0].OpenReadStream())
                {
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                }
                productCreateEditVM.Product.Picture = p1;
            }

            await _productService.Create(productCreateEditVM.Product);
            return RedirectToAction(nameof(Index));
        }
    }
}
