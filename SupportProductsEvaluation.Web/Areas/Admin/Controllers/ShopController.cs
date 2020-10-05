using Microsoft.AspNetCore.Mvc;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Infrastructure.Pagination;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using SupportProductsEvaluation.Infrastructure.VMs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;
        private int PageSize = 1;
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }
        public async Task<IActionResult> Index(int productPage = 1)
        {

            ShopListViewModel shopListVM= new ShopListViewModel()
            {
                Shops = await _shopService.GetAll()
            };

            int count =  shopListVM.Shops.Count;
            shopListVM.Shops = shopListVM.Shops.OrderByDescending(p => p.Id)
                                 .Skip((productPage - 1) * PageSize)
                                 .Take(PageSize).ToList();
            shopListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                urlParam = "/Admin/Shop/Index?productPage=:"
            };
            return View(shopListVM);
        }
            

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Shop shop)
        {
            if (ModelState.IsValid)
            {
                await _shopService.Create(shop);
                return RedirectToAction(nameof(Index));
            }
            return View(shop);
        }
        public async Task<IActionResult>Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopEntity = await _shopService.Get(id.Value);
            if (shopEntity == null)
            {
                return NotFound();
            }
            return View(shopEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Shop shop)
        {
            if (ModelState.IsValid)
            {
                await _shopService.Update(shop);
                return RedirectToAction(nameof(Index));
            }
            return View(shop);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopEntity = await _shopService.Get(id.Value);
            if (shopEntity == null)
            {
                return NotFound();
            }
            return View(shopEntity);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id== null)
            {
                return NotFound();
            }

            var shopEntity =await _shopService.Get(id.Value);
            if (shopEntity == null)
            {
                return NotFound();
            }

            return View(shopEntity);

        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>DeleteConfirmed(int id)
        {
            var shopEntity = await _shopService.Get(id);
            if (shopEntity == null)
            {
                return View();
            }
            await _shopService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
