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

        private readonly int PageSize=5;
        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
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
                urlParam = "/Admin/Product/Index?productPage=:"
            };
            return View(productListVM);
        }

        public IActionResult Privacy()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
