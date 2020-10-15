using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Infrastructure.Pagination;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using SupportProductsEvaluation.Infrastructure.Utility;
using SupportProductsEvaluation.Infrastructure.VMs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.Admin)]
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;
        private int PageSize = 5;

        public SubCategoryController(ISubCategoryService subCategoryService, ICategoryService categoryService)
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int productPage = 1, string searchCategoryName = null, string searchSubCategoryName = null)
        {
            SubCategoryListVM subCategoryListVM = new SubCategoryListVM()
            {
                SubCategories = await _subCategoryService.GetAll()
            };

            if(searchCategoryName != null&& searchSubCategoryName != null)
            {
                subCategoryListVM.SubCategories = subCategoryListVM.SubCategories.Where(s => s.Category.Name.ToLower()
                                     .Contains(searchCategoryName.ToLower())&& s.Name.ToLower()
                                     .Contains(searchSubCategoryName.ToLower())).OrderByDescending(o => o.Name)
                                     .ToList();
            }

            else if (searchCategoryName != null)
            {
                subCategoryListVM.SubCategories = subCategoryListVM.SubCategories.Where(s => s.Category.Name.ToLower()
                                     .Contains(searchCategoryName.ToLower())).OrderByDescending(o => o.Name)
                                     .ToList();
            }

            else if (searchSubCategoryName != null)
            {
                subCategoryListVM.SubCategories = subCategoryListVM.SubCategories.Where(s => s.Name.ToLower()
                                     .Contains(searchSubCategoryName.ToLower())).OrderByDescending(o => o.Name)
                                     .ToList();
            }

            int count = subCategoryListVM.SubCategories.Count;
            subCategoryListVM.SubCategories = subCategoryListVM.SubCategories.OrderByDescending(p => p.Id)
                                     .Skip((productPage - 1) * PageSize)
                                     .Take(PageSize).ToList();
            subCategoryListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                urlParam = "/Admin/SubCategory/Index?productPage=:"
            };
            return View(subCategoryListVM);
        }

        public async Task<IActionResult> Create()
        {
            SubCategoryAndCategoryVM subCategoryAndCategoryVM = new SubCategoryAndCategoryVM()
            {
                CategoryList = await _categoryService.GetAll(),
                SubCategory = new SubCategory(),
            };
            ViewBag.IsExist = false;
            return View(subCategoryAndCategoryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubCategoryAndCategoryVM subCategoryAndCategoryVM)
        {
            if (ModelState.IsValid)
            {
                var IsExist=await _subCategoryService.IsExist(subCategoryAndCategoryVM.SubCategory);
                if (IsExist)
                {
                    ViewBag.IsExist = true;
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

            subCategoryAndCategoryVM = new SubCategoryAndCategoryVM
            {
                CategoryList = await _categoryService.GetAll(),
                SubCategory = subCategoryAndCategoryVM.SubCategory
            };
            
            return View(subCategoryAndCategoryVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _subCategoryService.Get(id);

            if (subCategory == null)
            {
                return NotFound();
            }

            SubCategoryAndCategoryVM subCategoryAndCategoryVM= new SubCategoryAndCategoryVM()
            {
                CategoryList = await _categoryService.GetAll(),
                SubCategory = subCategory,
            };

            ViewBag.IsExist = false;
            return View(subCategoryAndCategoryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubCategoryAndCategoryVM subCategoryAndCategoryVM)
        {

            SubCategoryAndCategoryVM subCategoryAndCategoryErrorVM = new SubCategoryAndCategoryVM
            {
                CategoryList = await _categoryService.GetAll(),
                SubCategory = subCategoryAndCategoryVM.SubCategory
            };

            if (ModelState.IsValid)
            {
                var IsExist = await _subCategoryService.IsExist(subCategoryAndCategoryVM.SubCategory);
                if (IsExist)
                {
                    ViewBag.IsExist = true;
                    return View(subCategoryAndCategoryErrorVM);
                }
             
                await _subCategoryService.Update(subCategoryAndCategoryVM.SubCategory);
                return RedirectToAction(nameof(Index));

            }

            return View(subCategoryAndCategoryErrorVM);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subCategory = await _subCategoryService.Get(id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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

