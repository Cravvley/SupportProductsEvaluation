using Microsoft.AspNetCore.Mvc;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Infrastructure.Pagination;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using SupportProductsEvaluation.Infrastructure.VMs;
using System.Linq;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IProductService _productService;

        private int PageSize = 5;
        public ReportController(IReportService reportService, IProductService productService)
        {
            _reportService = reportService;
            _productService = productService;
        }
        public async Task<IActionResult> Index(int productPage = 1, string searchName = null, string searchCategory = null)
        {
            ReportListVM reportListVM = new ReportListVM()
            {
                Reports = await _reportService.GetAll()
            };

            if (searchName != null && searchCategory != null)
            {
                reportListVM.Reports = reportListVM.Reports.Where(s => s.ProductName.ToLower()
                                      .Contains(searchName.ToLower()) && s.CategoryName.ToLower().Contains(searchCategory.ToLower()))
                                        .OrderByDescending(o => o.ProductName)
                                        .ToList();
            }
            else if (searchName != null)
            {
                reportListVM.Reports = reportListVM.Reports.Where(s => s.ProductName.ToLower()
                                      .Contains(searchName.ToLower())).OrderByDescending(o => o.ProductName)
                                     .ToList();
            }
            else if (searchCategory != null)
            {
                reportListVM.Reports = reportListVM.Reports.Where(s => s.CategoryName.ToLower()
                                      .Contains(searchCategory.ToLower())).OrderByDescending(o => o.ProductName)
                                     .ToList();
            }

            int count = reportListVM.Reports.Count;
            reportListVM.Reports = reportListVM.Reports.OrderByDescending(p => p.Id)
                                     .Skip((productPage - 1) * PageSize)
                                     .Take(PageSize).ToList();

            reportListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                urlParam = "/Admin/Report/Index?productPage=:"
            };
            return View(reportListVM);
        }

        public IActionResult Create()
        {
            ViewBag.IsProductExist = true;
            ViewBag.IsCopy = false;


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Report report)
        {
            if (ModelState.IsValid)
            {
                var isCopy = await _reportService.IsExist(report);
                if (isCopy)
                {
                    ViewBag.IsCopy = true;
                    ViewBag.IsProductExist = true;
                    return View(report);
                }
                var isProductExist = await _productService.IsExist(report.ProductName, report.CategoryName, report.SubCategoryName);
                if (!isProductExist)
                {
                    ViewBag.IsCopy = false;
                    ViewBag.IsProductExist = false;
                    return View(report);
                }

                await _reportService.Create(report);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IsCopy = false;
            ViewBag.IsProductExist = true;
            return View(report);
        }

        public async Task<IActionResult> Edit(int ?id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportEntity = await _reportService.Get(id);
            if (reportEntity== null)
            {
                return NotFound();
            }

            ViewBag.IsProductExist = true;

            return View(reportEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Report report)
        {
            if (ModelState.IsValid)
            {
              
                var isProductExist = await _productService.IsExist(report.ProductName, report.CategoryName, report.SubCategoryName);
                if (!isProductExist)
                {
                    ViewBag.IsProductExist = false;
                    return View(report);
                }

                await _reportService.Update(report);
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.IsProductExist = true;
            return View(report);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportEntity = await _reportService.Get(id);
            if (reportEntity == null)
            {
                return NotFound();
            }

            return View(reportEntity);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportEntity = await _reportService.Get(id);
            if (reportEntity == null)
            {
                return View();
            }
            await _reportService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _reportService.Get(id);


            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }
    }
}
