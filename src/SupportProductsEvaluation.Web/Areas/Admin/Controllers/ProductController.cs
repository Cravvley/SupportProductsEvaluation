using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SupportProductsEvaluation.Infrastructure.DTOs;
using SupportProductsEvaluation.Infrastructure.Pagination;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using SupportProductsEvaluation.Infrastructure.Utility;
using SupportProductsEvaluation.Infrastructure.VMs;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.Admin)]
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IShopService _shopService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;

        private int PageSize = 5;
        public ProductController(IProductService productService, IShopService shopService, ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _productService = productService;
            _shopService = shopService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }


        public async Task<IActionResult> Index(int productPage = 1, string searchByProduct = null, string searchByCategory = null)
        {
            ProductListVM productListVM = new ProductListVM()
            {
                Products = await _productService.GetAllHeaders(),
            };

            if (searchByProduct != null && searchByCategory != null)
            {
                productListVM.Products = productListVM.Products.Where(s => s.Name.ToLower()
                                      .Contains(searchByProduct.ToLower()) && s.Category.Name.ToLower()
                                      .Contains(searchByCategory.ToLower())).OrderByDescending(o => o.Name)
                                     .ToList();
            }

            else if (searchByProduct != null)
            {
                productListVM.Products = productListVM.Products.Where(s => s.Name.ToLower()
                                      .Contains(searchByProduct.ToLower()))
                                      .OrderByDescending(o => o.Name).ToList();
            }

            else if (searchByCategory != null)
            {
                productListVM.Products = productListVM.Products.Where(s => s.Category.Name.ToLower()
                                      .Contains(searchByCategory.ToLower()))
                                      .OrderByDescending(o => o.Name).ToList();
            }

            int count = productListVM.Products.Count;
            productListVM.Products = productListVM.Products.OrderByDescending(p => p.Id)
                                     .Skip((productPage - 1) * PageSize)
                                     .Take(PageSize).ToList();
            productListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                UrlParam = "/Admin/Product/Index?productPage=:"
            };
            return View(productListVM);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.IsExist = false;

            ProductCreateEditVM productCreateEditVMError = new ProductCreateEditVM()
            {
                Product = new ProductDto(),
                CategoryList = await _categoryService.GetAll(),
                ShopList = await _shopService.GetAllDetails()
            };

            return View(productCreateEditVMError);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateEditVM productCreateEditVM)
        {

            ProductCreateEditVM productCreateEditVMError = new ProductCreateEditVM()
            {
                Product = productCreateEditVM.Product,
                CategoryList = await _categoryService.GetAll(),
                ShopList = await _shopService.GetAllDetails()
            };

            if (ModelState.IsValid)
            {
                productCreateEditVM.Product.SubCategoryId = Convert.ToInt32(Request.Form["SubCategoryId"].ToString());
                var isExist = await _productService.IsExist(productCreateEditVM.Product);

                if (isExist)
                {
                    ViewBag.isExist = true;
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

            ViewBag.isExist = false;
            return View(productCreateEditVMError);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _productService.GetDto(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetDto(id);


            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductCreateEditVM productCreateEditVM = new ProductCreateEditVM()
            {
                Product = await _productService.GetDto(id),
                CategoryList = await _categoryService.GetAll(),
                ShopList = await _shopService.GetAllDetails()
            };

            return View(productCreateEditVM);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPOST(ProductCreateEditVM productCreateEditVM)
        {
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

            await _productService.Update(productCreateEditVM.Product);
            return RedirectToAction(nameof(Index));

        }

    }
}
