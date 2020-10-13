using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupportProductsEvaluation.Infrastructure.Pagination;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using SupportProductsEvaluation.Infrastructure.VMs;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Web.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IReportService _reportService;

        private readonly int PageSize = 5;
        public HomeController(ILogger<HomeController> logger, IProductService productService, IReportService reportService)
        {
            _logger = logger;
            _productService = productService;
            _reportService = reportService;
        }

        public async Task<IActionResult> Index(int productPage = 1, string searchName = null, string searchCategoryName = null)
        {
            ProductListVM productListVM = new ProductListVM()
            {
                Products = await _productService.GetAllHeaders()
            };

            if (searchName != null && searchCategoryName != null)
            {
                productListVM.Products = productListVM.Products.Where(s => s.Name.ToLower()
                                      .Contains(searchName.ToLower()) && s.Category.Name.ToLower()
                                      .Contains(searchCategoryName.ToLower())).OrderByDescending(o => o.Name)
                                     .ToList();
            }

            else if (searchName != null)
            {
                productListVM.Products = productListVM.Products.Where(s => s.Name.ToLower()
                                      .Contains(searchName.ToLower()))
                                      .OrderByDescending(o => o.Name).ToList();
            }

            else if (searchCategoryName != null)
            {
                productListVM.Products = productListVM.Products.Where(s => s.Category.Name.ToLower()
                                      .Contains(searchCategoryName.ToLower()))
                                      .OrderByDescending(o => o.Name).ToList();
            }

            int count = productListVM.Products.Count;
            productListVM.Products = productListVM.Products.OrderByDescending(p => p.Id)
                                     .Skip((productPage - 1) * PageSize)
                                     .Take(PageSize).ToList();
            productListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                urlParam = "/User/Home/Index?productPage=:"
            };
            return View(productListVM);
        }

        public async Task<IActionResult> Reports(int productPage = 1, string searchName = null, string searchCategory = null)
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
                urlParam = "/User/Home/Reports?productPage=:"
            };
            return View(reportListVM);
        }


        public async Task<IActionResult> ReportDetails(int? id)
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
