using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Infrastructure.Pagination;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using SupportProductsEvaluation.Infrastructure.Utility;
using SupportProductsEvaluation.Infrastructure.VMs;
using System.Linq;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.Admin)]
    [Area("Admin")]
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;
        private int PageSize = 5;
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }
        public async Task<IActionResult> Index(int productPage = 1, string searchName = null, string searchCity = null)
        {

            ShopListVM shopListVM = new ShopListVM()
            {
                Shops = await _shopService.GetAllHeaders()
            };
            
            if (searchName != null & searchCity != null)
            {
                shopListVM.Shops = shopListVM.Shops.Where(s => s.Name.ToLower()
                                    .Contains(searchName.ToLower()) && s.City.ToLower()
                                    .Contains(searchCity.ToLower())).OrderByDescending(o => o.Name)
                                    .ToList();
            }
            else if (searchName != null)
            {
                shopListVM.Shops = shopListVM.Shops.Where(s => s.Name.ToLower()
                                    .Contains(searchName.ToLower())).OrderByDescending(o => o.Name)
                                    .ToList();
            }
            else if (searchCity != null)
            {
                shopListVM.Shops = shopListVM.Shops.Where(s => s.City.ToLower()
                                    .Contains(searchCity.ToLower())).OrderByDescending(o => o.City)
                                    .ToList();
            }

            int count = shopListVM.Shops.Count;
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
            ViewBag.IsExist = false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Shop shop)
        {
            if (ModelState.IsValid)
            {
                var isExist = await _shopService.IsExist(shop);
                if (isExist)
                {
                    ViewBag.IsExist = true;
                    return View(shop);
                }
                
                await _shopService.Create(shop);
                return RedirectToAction(nameof(Index));
            }
            return View(shop);
        }
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var shopEntity = await _shopService.Get(id);
            if (shopEntity == null)
            {
                return NotFound();
            }

            ViewBag.IsExist = false;
            return View(shopEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Shop shop)
        {
            if (ModelState.IsValid)
            {
                var isExist = await _shopService.IsExist(shop);
                if (isExist)
                {
                    ViewBag.IsExist = true;
                    return View(shop);
                }

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

            var shopEntity = await _shopService.Get(id);
            if (shopEntity == null)
            {
                return NotFound();
            }
            return View(shopEntity);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopEntity = await _shopService.Get(id);
            if (shopEntity == null)
            {
                return NotFound();
            }

            return View(shopEntity);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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
