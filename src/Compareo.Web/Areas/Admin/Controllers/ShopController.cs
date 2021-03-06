﻿using Compareo.Data.Entities;
using Compareo.Infrastructure.Common.Pagination;
using Compareo.Infrastructure.Common.StaticFiles;
using Compareo.Infrastructure.Services.Interfaces;
using Compareo.Infrastructure.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Compareo.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Constants.Admin)]
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;
        private readonly IShopPropositionService _shopPropositionService;

        private const int PageSize = 5;

        public ShopController(IShopService shopService, IShopPropositionService shopPropositionService)
        {
            _shopService = shopService;
            _shopPropositionService = shopPropositionService;
        }

        public async Task<IActionResult> Index(int productPage = 1, string searchByShop = null, string searchByCity = null)
        {
            var (shops, shopsCount) = await _shopService.GetFiltered(searchByShop,searchByCity, PageSize, productPage);

            var shopListVM = new ShopListVM()
            {
                Shops = shops
            };

            const string Url = "/Admin/Shop/Index?productPage=:";

            shopListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = shopsCount,
                UrlParam = Url
            };

            return View(shopListVM);
        }

        public IActionResult Create()
        {
            ViewBag.Exist = false;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
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

        [HttpPost, ValidateAntiForgeryToken]
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

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _shopService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShopPropositionList(int productPage = 1)
        {

            var shopPropositionListVM = new ShopPropositionListVM()
            {
                ShopPropositions = await _shopPropositionService.GetAll()
            };

            var count = shopPropositionListVM.ShopPropositions.Count;

            shopPropositionListVM.ShopPropositions = await _shopPropositionService.GetPaginated(PageSize, productPage);

            const string Url = "/Admin/Shop/ShopPropositionList?productPage=:";

            shopPropositionListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                UrlParam = Url
            };

            return View(shopPropositionListVM);
        }

        public async Task<IActionResult> ShopPropositionDetails(int id)
            => View(await _shopPropositionService.Get(id));

        public async Task<IActionResult> ShopPropositionAccept(int id)
        {
            var shopPropositionItem = await _shopPropositionService.Get(id);

            await _shopService.AcceptProposition(shopPropositionItem);

            await _shopPropositionService.Delete(id);

            return RedirectToAction("ShopPropositionList");
        }
        public async Task<IActionResult> ShopPropositionDiscard(int id)
        {
            await _shopPropositionService.Delete(id);

            return RedirectToAction("ShopPropositionList");
        }

    }
}
