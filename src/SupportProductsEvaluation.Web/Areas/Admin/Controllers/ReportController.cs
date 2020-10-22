using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IProductService _productService;

        private const int PageSize = 5;
        public ReportController(IReportService reportService, IProductService productService)
        {
            _reportService = reportService;
            _productService = productService;
        }

        public async Task<IActionResult> Index(int productPage = 1, string searchByProduct = null, string searchByCategory = null)
        {
            var reportListVM = new ReportListVM()
            {
                Reports = await _reportService.GetAll()
            };

            var count = reportListVM.Reports.Count;

            reportListVM.Reports = await _reportService.GetPaginated(null, PageSize, productPage);

            if (!(searchByProduct is null && searchByCategory is null))
            {
                reportListVM.Reports = await _reportService.GetPaginated(s => s.ProductName.ToLower()
                                      .Contains(searchByProduct.ToLower()) && s.CategoryName.ToLower().Contains(searchByCategory.ToLower()), PageSize, productPage);

                count = reportListVM.Reports.Count;
            }
            else if (!(searchByProduct is null))
            {
                reportListVM.Reports = await _reportService.GetPaginated(s => s.ProductName.ToLower()
                                      .Contains(searchByProduct.ToLower()), PageSize, productPage);

                count = reportListVM.Reports.Count;
            }
            else if (!(searchByCategory is null))
            {
                reportListVM.Reports = await _reportService.GetPaginated(s => s.CategoryName.ToLower()
                                      .Contains(searchByCategory.ToLower()), PageSize, productPage);

                count = reportListVM.Reports.Count;
            }

            const string Url = "/Admin/Report/Index?productPage=:";

            reportListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                UrlParam = Url
            };

            return View(reportListVM);
        }

        public IActionResult Create()
        {
            ViewBag.ProductExist = true;
            ViewBag.IsCopy = false;


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Report report)
        {
            if (ModelState.IsValid)
            {
                var isCopy = await _reportService.Exist(r => r.ProductName == report.ProductName &&
                                                         r.SubCategoryName == report.SubCategoryName &&
                                                         r.CategoryName==report.CategoryName);

                if (isCopy)
                {
                    ViewBag.IsCopy = true;
                    ViewBag.productExist = true;
                    return View(report);
                }

                var productExist = await _productService.Exist(p => p.Name.ToLower() == report.ProductName.ToLower() &&
                                         p.Category.Name == report.CategoryName &&
                                         p.SubCategory.Name == report.SubCategoryName);
                if (!productExist)
                {
                    ViewBag.IsCopy = false;
                    ViewBag.ProductExist = false;
                    return View(report);
                }

                await _reportService.Create(report);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.IsCopy = false;
            ViewBag.ProductExist = true;

            return View(report);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.ProductExist = true;

            return View(await _reportService.Get(id));
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Report report)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProductExist = true;
                return View(report);
            }

            var productExist = await _productService.Exist(p => p.Name.ToLower() == report.ProductName.ToLower() &&
                                     p.Category.Name == report.CategoryName &&
                                     p.SubCategory.Name == report.SubCategoryName);
            if (!productExist)
            {
                ViewBag.ProductExist = false;
                return View(report);
            }

            await _reportService.Update(report);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
            => View(await _reportService.Get(id));

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _reportService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
            => View(await _reportService.Get(id));

    }
}
