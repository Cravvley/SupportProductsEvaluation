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
    [Authorize(Roles = SD.Admin)]
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        
        private const int PageSize = 5;
        
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int productPage = 1, string searchName = null)
        {
            var categoryListVM = new CategoryListVM()
            {
                Categories = await _categoryService.GetAll()
            };

            var count = categoryListVM.Categories.Count;

            categoryListVM.Categories = await _categoryService.GetPaginated(null, PageSize, productPage);

            if (searchName != null)
            {
                categoryListVM.Categories = await _categoryService.GetPaginated(p => p.Name.ToLower().Contains(searchName.ToLower()), PageSize, productPage);
                count = categoryListVM.Categories.Count;
            }

            const string Url = "/Admin/Category/Index?productPage=:";

            categoryListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                urlParam = Url
            };

            return View(categoryListVM);
        }

        public IActionResult Create()
        {
            ViewBag.Exist = false;
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            var exist = await _categoryService.Exist(x => x.Name.ToLower() == category.Name.ToLower());
            if (exist)
            {
                ViewBag.Exist = true;
                return View(category);
            }

            await _categoryService.Create(category);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var categoryEntity = await _categoryService.Get(id);

            ViewBag.Exist = false;

            return View(categoryEntity);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            var exist = await _categoryService.Exist(x => x.Name.ToLower() == category.Name.ToLower());
            if (exist)
            {
                ViewBag.IsExist = true;
                return View(category);
            }

            await _categoryService.Update(category);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
                => View(await _categoryService.Get(id));

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
