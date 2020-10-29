using Compareo.Infrastructure.Common.Pagination;
using Compareo.Infrastructure.Common.StaticFiles;
using Compareo.Infrastructure.DTOs;
using Compareo.Infrastructure.Services.Interfaces;
using Compareo.Infrastructure.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Compareo.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Constants.Admin)]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IShopService _shopService;
        private readonly ICategoryService _categoryService;
        private readonly IProductPropositionService _productPropositionService;

        private const int PageSize = 5;
        public ProductController(IProductService productService, IShopService shopService,
            ICategoryService categoryService, IProductPropositionService productPropositionService)
        {
            _productService = productService;
            _shopService = shopService;
            _categoryService = categoryService;
            _productPropositionService = productPropositionService;
        }

        public async Task<IActionResult> Index(int productPage = 1, string searchByProduct = null, string searchByCategory = null, string searchByShop = null)
        {
            var (products, productsCount) = await _productService.GetFiltered(searchByProduct, searchByCategory, searchByShop, PageSize, productPage);

            var productListVM = new ProductListVM()
            {
                Products = products,
            };

            const string Url = "/Admin/Product/Index?productPage=:";

            productListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = productsCount,
                UrlParam = Url
            };

            return View(productListVM);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Exist = false;

            var shops = await _shopService.GetAllHeaders();

            ViewBag.ShopsSelectList = new SelectList(shops.Select(p => new
            {
                Text = $"Shop: {p.Name}, {p.City} {p.StreetAddress} {p.PostalCode}",
                p.Id
            }), "Id", "Text");

            return View(new ProductDto());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            var shops = await _shopService.GetAllHeaders();

            ViewBag.ShopsSelectList = new SelectList(shops.Select(p => new
            {
                Text = $"Shop: {p.Name}, {p.City} {p.StreetAddress} {p.PostalCode}",
                p.Id
            }), "Id", "Text");

            if (!ModelState.IsValid)
            {
                ViewBag.Exist = false;
                return View(productDto);
            }

            var exist = await _productService.Exist(p => p.Name.ToLower() == productDto.Name.ToLower() &&
                                 p.CategoryId == productDto.CategoryId
                                 && p.ShopId == productDto.ShopId);

            if (exist)
            {
                ViewBag.Exist = true;
                return View(productDto);
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
                productDto.Picture = p1;
            }

            await _productService.Create(productDto);
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

            var shops = await _shopService.GetAllHeaders();

            ViewBag.ShopsSelectList = new SelectList(shops.Select(p => new
            {
                Text = $"Shop: {p.Name}, {p.City} {p.StreetAddress} {p.PostalCode}",
                p.Id
            }), "Id", "Text");

            return View(await _productService.GetDto(id));
        }


        [HttpPost, ActionName("Edit"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPOST(ProductDto productDto)
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
                productDto.Picture = p1;
            }

            await _productService.Update(productDto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ProductPropositionList(int productPage = 1)
        {

            var productPropositionListVM = new ProductPropositionListVM()
            {
                ProductPropositions = await _productPropositionService.GetAll()
            };

            var count = productPropositionListVM.ProductPropositions.Count;

            productPropositionListVM.ProductPropositions = await _productPropositionService.GetPaginated(PageSize, productPage);


            const string Url = "/Admin/Product/ProductPropositionList?productPage=:";

            productPropositionListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                UrlParam = Url
            };

            return View(productPropositionListVM);
        }

        public async Task<IActionResult> ProductPropositionDetails(int id)
            => View(await _productPropositionService.Get(id));

        public async Task<IActionResult> ProductPropositionAccept(int id)
        {
            var productPropositionItem = await _productPropositionService.Get(id);

            await _productService.AcceptProposition(productPropositionItem);

            await _productPropositionService.Delete(id);

            return RedirectToAction("ProductPropositionList");
        }
        public async Task<IActionResult> ProductPropositionDiscard(int id)
        {
            await _productPropositionService.Delete(id);
            return RedirectToAction("ProductPropositionList");
        }

    }
}
