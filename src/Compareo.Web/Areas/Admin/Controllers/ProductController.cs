﻿using Compareo.Infrastructure.DTOs;
using Compareo.Infrastructure.Pagination;
using Compareo.Infrastructure.Services.Interfaces;
using Compareo.Infrastructure.Utility;
using Compareo.Infrastructure.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Compareo.Web.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize(Roles = SD.Admin)]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IShopService _shopService;
        private readonly ICategoryService _categoryService;

        private const int PageSize = 5;
        public ProductController(IProductService productService, IShopService shopService, ICategoryService categoryService)
        {
            _productService = productService;
            _shopService = shopService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int productPage = 1, string searchByProduct = null, string searchByCategory = null)
        {
            var productListVM = new ProductListVM()
            {
                Products = await _productService.GetAllHeaders(),
            };

            var count = productListVM.Products.Count;

            productListVM.Products = await _productService.GetPaginated(null, PageSize, productPage);

            if (!(searchByProduct is null || searchByCategory is null))
            {
                productListVM.Products = await _productService.GetPaginated(s => s.Name.ToLower()
                                      .Contains(searchByProduct.ToLower()) && s.Category.Name.ToLower()
                                      .Contains(searchByCategory.ToLower()));

                count = productListVM.Products.Count;
            }

            else if (!(searchByProduct is null))
            {
                productListVM.Products = await _productService.GetPaginated(s => s.Name.ToLower()
                                      .Contains(searchByProduct.ToLower()));


                count = productListVM.Products.Count;
            }

            else if (!(searchByCategory is null))
            {
                productListVM.Products = await _productService.GetPaginated(s => s.Category.Name.ToLower()
                                      .Contains(searchByCategory.ToLower()));

                count = productListVM.Products.Count;
            }

            const string Url = "/Admin/Product/Index?productPage=:";

            productListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                UrlParam = Url
            };

            return View(productListVM);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Exist = false;

            var productCreateEditVMError = new ProductCreateEditVM()
            {
                Product = new ProductDto(),
                ShopList = await _shopService.GetAllDetails()
            };

            return View(productCreateEditVMError);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateEditVM productCreateEditVM)
        {

            var productCreateEditVMError = new ProductCreateEditVM()
            {
                Product = productCreateEditVM.Product,
                ShopList = await _shopService.GetAllDetails()
            };

            if (!ModelState.IsValid)
            {
                ViewBag.Exist = false;
                return View(productCreateEditVMError);
            }

            var exist = await _productService.Exist(p => p.Name.ToLower() == productCreateEditVM.Product.Name.ToLower() &&
                                 p.CategoryId == productCreateEditVM.Product.CategoryId
                                 && p.ShopId == productCreateEditVM.Product.ShopId);

            if (exist)
            {
                ViewBag.Exist = true;
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

        public async Task<IActionResult> Delete(int? id)
            => View(await _productService.GetDto(id));

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
                => View(await _productService.GetDto(id));

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var productCreateEditVM = new ProductCreateEditVM()
            {
                Product = await _productService.GetDto(id),
                ShopList = await _shopService.GetAllDetails()
            };

            return View(productCreateEditVM);
        }

        [HttpPost, ActionName("Edit"), ValidateAntiForgeryToken]
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