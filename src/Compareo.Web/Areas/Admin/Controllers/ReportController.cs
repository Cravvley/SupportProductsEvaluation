using Compareo.Data.Entities;
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
            var (reports, reportsCount) = await _reportService.GetFiltered(searchByProduct, searchByCategory, PageSize, productPage);

            var reportListVM = new ReportListVM()
            {
                Reports = reports
            };

            const string Url = "/Admin/Report/Index?productPage=:";

            reportListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = reportsCount,
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

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Report report)
        {
            if (ModelState.IsValid)
            {
                var isCopy = await _reportService.Exist(r => r.ProductName.ToLower() == report.ProductName.ToLower() && r.CategoryId==report.CategoryId);

                if (isCopy)
                {
                    ViewBag.IsCopy = true;
                    ViewBag.productExist = true;
                    return View(report);
                }

                var productExist = await _productService.Exist(p => p.Name.ToLower() == report.ProductName.ToLower() &&
                                         p.Category.Id == report.CategoryId);
                                         
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

        public async Task<IActionResult> GenerateReports()
        {
            await _reportService.GenerateReports();

            return RedirectToAction(nameof(Index));
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
                                     p.Category.Id == report.CategoryId);
                                     
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
