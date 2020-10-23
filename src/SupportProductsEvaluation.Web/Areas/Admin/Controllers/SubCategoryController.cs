using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SupportProductsEvaluation.Data.Entities;
using SupportProductsEvaluation.Infrastructure.Pagination;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using SupportProductsEvaluation.Infrastructure.Utility;
using SupportProductsEvaluation.Infrastructure.VMs;
using System.Linq;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = SD.Admin)]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;

        private const int PageSize = 5;

        public SubCategoryController(ISubCategoryService subCategoryService, ICategoryService categoryService)
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int productPage = 1, string searchByCategory = null, string searchBySubcategory = null)
        {
            var subCategoryListVM = new SubCategoryListVM()
            {
                SubCategories = await _subCategoryService.GetAll()
            };

            var count = subCategoryListVM.SubCategories.Count;

            subCategoryListVM.SubCategories = await _subCategoryService.GetPaginated(null, PageSize, productPage);

            if (!(searchByCategory is null || searchBySubcategory is null))
            {
                subCategoryListVM.SubCategories = await _subCategoryService.GetPaginated(s => s.Category.Name.ToLower()
                                      .Contains(searchByCategory.ToLower()) && s.Name.ToLower()
                                      .Contains(searchBySubcategory.ToLower()), PageSize, productPage);

                count = subCategoryListVM.SubCategories.Count;
            }

            else if (!(searchByCategory is null))
            {
                subCategoryListVM.SubCategories = await _subCategoryService.GetPaginated(s => s.Category.Name.ToLower()
                                     .Contains(searchByCategory.ToLower()), PageSize, productPage);

                count = subCategoryListVM.SubCategories.Count;
            }

            else if (!(searchBySubcategory is null))
            {
                subCategoryListVM.SubCategories = await _subCategoryService.GetPaginated(s => s.Name.ToLower()
                                      .Contains(searchBySubcategory.ToLower()), PageSize, productPage);

                count = subCategoryListVM.SubCategories.Count;
            }

            const string Url = "/Admin/SubCategory/Index?productPage=:";

            subCategoryListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                UrlParam = Url
            };
            return View(subCategoryListVM);
        }

        public async Task<IActionResult> Create()
        {
            var subCategoryAndCategoryVM = new SubCategoryAndCategoryVM()
            {
                CategoryList = await _categoryService.GetAll(),
                SubCategory = new SubCategory(),
            };

            ViewBag.Exist = false;

            return View(subCategoryAndCategoryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubCategoryAndCategoryVM subCategoryAndCategoryVM)
        {
            if (!ModelState.IsValid)
            {
                subCategoryAndCategoryVM = new SubCategoryAndCategoryVM
                {
                    CategoryList = await _categoryService.GetAll(),
                    SubCategory = subCategoryAndCategoryVM.SubCategory
                };

                return View(subCategoryAndCategoryVM);
            }

            var exist = await _subCategoryService.Exist(sc => sc.Name.ToLower() == subCategoryAndCategoryVM.SubCategory.Name.ToLower()
            && sc.CategoryId == subCategoryAndCategoryVM.SubCategory.CategoryId);

            if (exist)
            {
                ViewBag.Exist = true;
                subCategoryAndCategoryVM = new SubCategoryAndCategoryVM
                {
                    CategoryList = await _categoryService.GetAll(),
                    SubCategory = new SubCategory()
                };
                return View(subCategoryAndCategoryVM);
            }

            await _subCategoryService.Create(subCategoryAndCategoryVM.SubCategory);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {

            var subCategoryAndCategoryVM = new SubCategoryAndCategoryVM()
            {
                CategoryList = await _categoryService.GetAll(),
                SubCategory = await _subCategoryService.Get(id),
        };

            ViewBag.Exist = false;

            return View(subCategoryAndCategoryVM);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubCategoryAndCategoryVM subCategoryAndCategoryVM)
        {
            var subCategoryAndCategoryErrorVM = new SubCategoryAndCategoryVM
            {
                CategoryList = await _categoryService.GetAll(),
                SubCategory = subCategoryAndCategoryVM.SubCategory
            };

            if (!ModelState.IsValid)
            {
                return View(subCategoryAndCategoryErrorVM);
            }

            var exist = await _subCategoryService.Exist(sc => sc.Name.ToLower() == subCategoryAndCategoryVM.SubCategory.Name.ToLower()
            && sc.CategoryId == subCategoryAndCategoryVM.SubCategory.CategoryId);

            if (exist)
            {
                ViewBag.Exist = true;
                return View(subCategoryAndCategoryErrorVM);
            }

            await _subCategoryService.Update(subCategoryAndCategoryVM.SubCategory);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
            => View(await _subCategoryService.Get(id));

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _subCategoryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }


        [ActionName("GetSubCategoryByCategory")]
        public async Task<IActionResult> GetSubCategoryByCategory(int id)
        {
            var subCategories = await _subCategoryService.GetAll(x => x.CategoryId == id);
            return Json(new SelectList(subCategories, "Id", "Name"));
        }

    }
}

