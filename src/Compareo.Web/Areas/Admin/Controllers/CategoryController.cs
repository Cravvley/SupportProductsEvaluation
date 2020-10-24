using Compareo.Data.Entities;
using Compareo.Infrastructure.Pagination;
using Compareo.Infrastructure.Services.Interfaces;
using Compareo.Infrastructure.Utility;
using Compareo.Infrastructure.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Web.Areas.Admin.Controllers
{

    [Area("Admin"), Authorize(Roles = SD.Admin)]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        private const int PageSize = 5;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int productPage = 1, string searchByCategory = null)
        {
            var categoryListVM = new CategoryListVM()
            {
                Categories = await _categoryService.GetAll(c => c.ParentCategoryId == null)
            };

            var count = categoryListVM.Categories.Count;

            categoryListVM.Categories = await _categoryService.GetPaginated(c => c.ParentCategoryId == null, PageSize, productPage);

            if (searchByCategory != null)
            {
                categoryListVM.Categories = await _categoryService.GetPaginated(c => c.Name.ToLower().Contains(searchByCategory.ToLower()) && c.ParentCategoryId == null,
                                                                                PageSize, productPage);
                count = categoryListVM.Categories.Count;
            }

            const string Url = "/Admin/Category/Index?productPage=:";

            categoryListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                UrlParam = Url
            };
            
            return View(categoryListVM);
        }

        public IActionResult Create(int? id = null)
        {
            ViewBag.Exist = false;

            var category = new Category();
            
            ViewBag.Title = "Category";

            if (!(id is null))
            {   
                category.ParentCategoryId = id;
                ViewBag.Title = "Subcategory";
            }

            return View(category);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            ViewBag.Title = "category";
            var exist = await _categoryService.Exist(c => c.Name.ToLower() == category.Name.ToLower()
                                &&c.ParentCategoryId==category.ParentCategoryId);

            if (!(category.ParentCategoryId is null))
            {
                exist = await _categoryService.Exist(c => c.Name.ToLower() == category.Name.ToLower()
                                           && c.ParentCategoryId == category.ParentCategoryId);

                ViewBag.Title = "subcategory";
            }

            if (exist)
            {
                ViewBag.Exist = true;
                return View(category);
            }

            category.Id = 0;
            await _categoryService.Create(category);

            if(!(category.ParentCategoryId is null))
            {
                return RedirectToAction($"Details",new { id=category.ParentCategoryId});
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
            => View(await _categoryService.Get(id));

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

