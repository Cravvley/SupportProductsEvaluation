using Microsoft.AspNetCore.Mvc;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }
        public async Task<IActionResult> Index()
            => View(await _shopService.GetAll());

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
