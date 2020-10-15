using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Infrastructure.Pagination;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using SupportProductsEvaluation.Infrastructure.Utility;
using SupportProductsEvaluation.Infrastructure.VMs;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Web.Areas.Admin.Controllers
{
    [Authorize(Roles =SD.Admin)]
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        private int PageSize = 5;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int productPage = 1, string searchName = null)
        {
            CategoryListVM categoryListVM = new CategoryListVM()
            {
                Categories = await _categoryService.GetAll()
            };

            if (searchName != null)
            {
                categoryListVM.Categories = categoryListVM.Categories.Where(s => s.Name.ToLower()
                                     .Contains(searchName.ToLower())).OrderByDescending(o => o.Name)
                                     .ToList();
            }

            int count = categoryListVM.Categories.Count;
            categoryListVM.Categories = categoryListVM.Categories.OrderByDescending(p => p.Id)
                                     .Skip((productPage - 1) * PageSize)
                                     .Take(PageSize).ToList();
            categoryListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                urlParam = "/Admin/Category/Index?productPage=:"
            };
            return View(categoryListVM);
        }

        public IActionResult Create()
        {
            ViewBag.IsExist = false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var isExist = await _categoryService.IsExist(category);
                if (isExist)
                {
                    ViewBag.IsExist = true;
                    return View(category);
                }

                await  _categoryService.Create(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var categoryEntity = await _categoryService.Get(id);
            if (categoryEntity == null)
            {
                return NotFound();
            }

            ViewBag.IsExist = false;
            return View(categoryEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var isExist = await _categoryService.IsExist(category);
                if (isExist)
                {
                    ViewBag.IsExist = true;
                    return View(category);
                }

                await _categoryService.Update(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryEntity = await _categoryService.Get(id);
            if (categoryEntity == null)
            {
                return NotFound();
            }

            return View(categoryEntity);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryEntity = await _categoryService.Get(id);
            if (categoryEntity == null)
            {
                return View();
            }
            await _categoryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

