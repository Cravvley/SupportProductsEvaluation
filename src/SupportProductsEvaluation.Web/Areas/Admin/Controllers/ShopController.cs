using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupportProductsEvaluation.Data.Entities;
using SupportProductsEvaluation.Infrastructure.Pagination;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using SupportProductsEvaluation.Infrastructure.Utility;
using SupportProductsEvaluation.Infrastructure.VMs;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = SD.Admin)]
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;
       
        private const int PageSize = 5;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        public async Task<IActionResult> Index(int productPage = 1, string searchName = null, string searchCity = null)
        {

            var shopListVM = new ShopListVM()
            {
                Shops = await _shopService.GetAllHeaders()
            };

            var count = shopListVM.Shops.Count;
            shopListVM.Shops = await _shopService.GetPaginatedHeaders(s=>true,PageSize,productPage);
            if (searchName != null & searchCity != null)
            {
                shopListVM.Shops = await _shopService.GetPaginatedHeaders(s => s.Name.ToLower()
                                    .Contains(searchName.ToLower()) && s.City.ToLower()
                                    .Contains(searchCity.ToLower()));
        
                count = shopListVM.Shops.Count;
            }
            else if (searchName != null)
            {
                shopListVM.Shops = await _shopService.GetPaginatedHeaders(s => s.Name.ToLower().Contains(searchName.ToLower()),PageSize, productPage);
                
                count = shopListVM.Shops.Count;
            }
            else if (searchCity != null)
            {
                shopListVM.Shops = await _shopService.GetPaginatedHeaders(s => s.City.ToLower().Contains(searchCity.ToLower()),PageSize, productPage);
                
                count = shopListVM.Shops.Count;
            }

            const string Url = "/Admin/Shop/Index?productPage=:";

            shopListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                urlParam = Url
            };

            return View(shopListVM);
        }

        public IActionResult Create()
        {
            ViewBag.Exist = false;
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return View(shop);
            }

            var exist = await _shopService.Exist(s => s.City.ToLower() == shop.City.ToLower() && s.Country.ToLower()
                                == shop.Country.ToLower() && s.Name.ToLower() == shop.Name.ToLower() && s.PostalCode.ToLower()
                                == shop.PostalCode.ToLower() && s.StreetAddress.ToLower() == shop.StreetAddress.ToLower());

            if (exist)
            {
                ViewBag.Exist = true;
                
                return View(shop);
            }

            await _shopService.Create(shop);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Exist = false;

            return View(await _shopService.Get(id));
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return View(shop);
            }

            var exist = await _shopService.Exist(s => s.City.ToLower() == shop.City.ToLower() && s.Country.ToLower()
                                == shop.Country.ToLower() && s.Name.ToLower() == shop.Name.ToLower() && s.PostalCode.ToLower()
                                == shop.PostalCode.ToLower() && s.StreetAddress.ToLower() == shop.StreetAddress.ToLower());
            if (exist)
            {
                ViewBag.Exist = true;
                
                return View(shop);
            }

            await _shopService.Update(shop);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
                     => View(await _shopService.Get(id));

        public async Task<IActionResult> Delete(int? id)
                => View(await _shopService.Get(id));

        [HttpPost, ActionName("Delete"),ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _shopService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
