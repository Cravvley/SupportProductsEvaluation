using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SupportProductsEvaluation.Data.Entities;
using SupportProductsEvaluation.Infrastructure.Pagination;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using SupportProductsEvaluation.Infrastructure.Utility;
using SupportProductsEvaluation.Infrastructure.VMs;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Web.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IReportService _reportService;
        private readonly IRateService _rateService;
        private readonly ICommentService _commentService;

        private readonly int PageSize = 9;
        public HomeController(ILogger<HomeController> logger, IProductService productService, IReportService reportService, IRateService rateService, ICommentService commentService)
        {
            _logger = logger;
            _productService = productService;
            _reportService = reportService;
            _rateService = rateService;
            _commentService = commentService;
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

        [Authorize(Roles = SD.Admin + ", " + SD.User)]
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


        [Authorize(Roles = SD.Admin + ", " + SD.User)]
        public async Task<IActionResult> ProductDetails(int id, int productPage = 1)
        {
            var product = await _productService.Get(id);

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ProductDetailsVM productDetailsVM = new ProductDetailsVM()
            {
                Product = product,
                Comment = new Comment()
                {
                    ProductId = id,
                    UserId = claim.Value

                },
            };

            var rate = await _rateService.Get(claim.Value, id);

            if (rate != null)
            {
                productDetailsVM.Rate = rate;
            }
            else
            {
                productDetailsVM.Rate = new Rate()
                {
                    ProductId = id,
                    UserId = claim.Value
                };
            }

            int count = productDetailsVM.Product.Comments.Count;
            productDetailsVM.Product.Comments = productDetailsVM.Product.Comments.OrderByDescending(p => p.UpdateAt)
                                     .Skip((productPage - 1) * PageSize)
                                     .Take(PageSize).ToList();

            productDetailsVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                urlParam = $"/User/Home/ProductDetails/{id}?productPage=:"
            };

            return View(productDetailsVM);
        }

        [Authorize(Roles = SD.Admin + ", " + SD.User)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddComentToProduct(Comment comment)
        {

            comment.UpdateAt = DateTime.Now;
            await _commentService.Add(comment);

            return RedirectToAction("ProductDetails", new { Id = comment.ProductId });
        }

        [Authorize(Roles = SD.Admin + ", " + SD.User)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddRateToProduct(Rate rate)
        {

            var rateEntity = await _rateService.Get(rate.Id);

            if (rateEntity == null)
            {
                await _rateService.Create(rate);
            }
            else
            {
                await _rateService.Update(rate);
            }

            return RedirectToAction("ProductDetails", new { Id = rate.ProductId });
        }


        [Authorize(Roles = SD.Admin + ", " + SD.User)]
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

        public async Task<IActionResult> Comparison()
        {
            var productEntities = await _productService.GetAllHeaders();
            var uniqueProducts = productEntities.Select(x => new { ProductName = x.Name, CategoryName = x.Category.Name, SubCategoryName = x.SubCategory.Name })
                                                .Distinct();

            ViewBag.ProductsSelectList = new SelectList(uniqueProducts.Select(p => new
            {
                Text = $"{p.ProductName}, {p.CategoryName}, {p.SubCategoryName}",
                Url = $"User/Home/ProductsLocalization?productName={p.ProductName}&categoryName={p.CategoryName}&subCategoryName={p.SubCategoryName}"
            }), "Url", "Text");

            return View();
        }


        public async Task<IActionResult> ProductsLocalization(string productName = null, string categoryName = null, string subCategoryName = null)
        {
            var products = await _productService.GetAllHeaders();

            var localizationList = products.Where(x => x.Name == productName && x.Category.Name == categoryName && x.SubCategory.Name == subCategoryName)
                                            .Select(p => new { p.Shop.Name, p.Shop.Country, p.Shop.PostalCode, p.Shop.StreetAddress, p.Shop.City }).ToList();

            var lolcalizationSelectList = new SelectList(localizationList.Select(s => new
            {
                Text = $"{s.Name}, {s.Country}, {s.City}, {s.StreetAddress}, {s.PostalCode}",
                Url = $"User/Home/ProductByShop?productName={productName}&categoryName={categoryName}&subCategoryName={subCategoryName}&shopName={s.Name}&country={s.Country}&city={s.City}&street={s.StreetAddress}&postalCode={s.PostalCode}"
            }), "Url", "Text"); ;

            return Json(lolcalizationSelectList);
        }

        public async Task<IActionResult> ProductByShop(string productName = null, string categoryName = null, string subCategoryName = null,string shopName = null, string country = null, string city = null, string street = null, string postalCode = null)
        {
            var productEntity = await _productService.Get(p=>p.Name==productName&&p.Category.Name==categoryName&&p.SubCategory.Name==subCategoryName
                                                            &&p.Shop.Name==shopName&&p.Shop.Country==country&& p.Shop.City == city &&
                                                            p.Shop.StreetAddress==street&&p.Shop.PostalCode==postalCode);

            var productDto = new {productEntity.Price, productEntity.AverageGrade, productEntity.Description};
            return Json(productDto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TODO()
        {
            return View();
        }
    }
}
