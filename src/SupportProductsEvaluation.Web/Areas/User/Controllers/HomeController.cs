using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IProductService _productService;
        private readonly IReportService _reportService;
        private readonly IRateService _rateService;
        private readonly ICommentService _commentService;

        private const int PageSize = 9;
        public HomeController(IProductService productService, IReportService reportService, IRateService rateService, ICommentService commentService)
        {
            _productService = productService;
            _reportService = reportService;
            _rateService = rateService;
            _commentService = commentService;
        }

        public async Task<IActionResult> Index(int productPage = 1, string searchByProduct = null, string searchByCategory = null)
        {
            var productListVM = new ProductListVM()
            {
                Products = await _productService.GetAllHeaders()
            };

            var count = productListVM.Products.Count;

            productListVM.Products = await _productService.GetPaginated(null, PageSize, productPage);

            if (!(searchByProduct is null || searchByCategory is null))
            {
                productListVM.Products = await _productService.GetPaginated(s => s.Name.ToLower()
                                        .Contains(searchByProduct.ToLower()) && s.Category.Name.ToLower()
                                        .Contains(searchByCategory.ToLower()), PageSize, productPage);

                count = productListVM.Products.Count;
            }

            else if (!(searchByProduct is null))
            {
                productListVM.Products = await _productService.GetPaginated(s => s.Name.ToLower()
                                       .Contains(searchByProduct.ToLower()));

                count = productListVM.Products.Count;
            }

            else if (!(searchByCategory is null))
            {
                productListVM.Products = await _productService.GetPaginated(s => s.Category.Name.ToLower()
                                      .Contains(searchByCategory.ToLower()));

                count = productListVM.Products.Count;
            }

            const string Url = "/User/Home/Index?productPage=:";
            productListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                UrlParam = Url
            };

            return View(productListVM);
        }

        [Authorize(Roles = SD.Admin + ", " + SD.User)]
        public async Task<IActionResult> Reports(int productPage = 1, string searchByProduct = null, string searchByCategory = null)
        {
            var reportListVM = new ReportListVM()
            {
                Reports = await _reportService.GetAll()
            };

            var count = reportListVM.Reports.Count;

            reportListVM.Reports = await _reportService.GetPaginated(r=>true, PageSize, productPage);

            if (!(searchByProduct is null && searchByCategory is null))
            {
                reportListVM.Reports = await _reportService.GetPaginated(r => r.ProductName.ToLower()
                                      .Contains(searchByProduct.ToLower()) && r.CategoryName.ToLower().
                                      Contains(searchByCategory.ToLower()), PageSize, productPage);

                count = reportListVM.Reports.Count;
            }
            else if (!(searchByProduct is null))
            {
                reportListVM.Reports = await _reportService.GetPaginated(r => r.ProductName.ToLower()
                                      .Contains(searchByProduct.ToLower()), PageSize, productPage);

                count = reportListVM.Reports.Count;
            }
            else if (!(searchByCategory is null))
            {
                reportListVM.Reports = await _reportService.GetPaginated(r => r.CategoryName.ToLower()
                                      .Contains(searchByCategory.ToLower()), PageSize, productPage);

                count = reportListVM.Reports.Count;
            }

            const string Url = "/User/Home/Reports?productPage=:";

            reportListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                UrlParam = Url
            };
            return View(reportListVM);
        }


        [Authorize(Roles = SD.Admin + ", " + SD.User)]
        public async Task<IActionResult> ProductDetails(int id, int productPage = 1)
        {
            var product = await _productService.Get(id);

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var productDetailsVM = new ProductDetailsVM()
            {
                Product = product,
                Comment = new Comment()
                {
                    ProductId = id,
                    UserId = claim.Value

                },
            };

            var rate = await _rateService.Get(x => x.UserId == claim.Value && x.ProductId == id);

            if (!(rate is null))
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

            var count = productDetailsVM.Product.Comments.Count;

            productDetailsVM.Product.Comments = await _commentService.GetPaginated(x=>x.ProductId == id, PageSize, productPage);

            string url = $"/User/Home/ProductDetails/{id}?productPage=:";

            productDetailsVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                UrlParam = url
            };

            return View(productDetailsVM);
        }

        [Authorize(Roles = SD.Admin + ", " + SD.User), HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> AddComentToProduct(Comment comment)
        {
            await _commentService.Add(comment);

            return RedirectToAction("ProductDetails", new { Id = comment.ProductId });
        }

        [Authorize(Roles = SD.Admin + ", " + SD.User), HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> AddRateToProduct(Rate rate)
        {

            var rateEntity = await _rateService.Get(rate.Id);

            if (rateEntity is null)
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
                    => Json(await _reportService.Get(id));

        [Authorize(Roles = SD.Admin + ", " + SD.User)]
        public async Task<IActionResult> Comparison()
        {
            var productEntities = await _productService.GetAllHeaders();
            var uniqueProducts = productEntities.Select(x => new { ProductName = x.Name, CategoryName = x.Category.Name, SubCategoryName = x.SubCategory.Name })
                                                .Distinct();

            ViewBag.ProductsSelectList = new SelectList(uniqueProducts.Select(p => new
            {
                Text = $"Product: {p.ProductName}, Category: {p.CategoryName}, Subcategory: {p.SubCategoryName}",
                Url = $"User/Home/ProductsLocalization?productName={p.ProductName}&categoryName={p.CategoryName}&subCategoryName={p.SubCategoryName}"
            }), "Url", "Text");

            return View();
        }

        [Authorize(Roles = SD.Admin + ", " + SD.User)]
        public async Task<IActionResult> ProductsLocalization(string productName = null, string categoryName = null, string subCategoryName = null)
        {
            var products = await _productService.GetAllHeaders();

            var localizationList = products.Where(x => x.Name == productName && x.Category.Name == categoryName && x.SubCategory.Name == subCategoryName)
                                            .Select(p => new { p.Shop.Name, p.Shop.Country, p.Shop.PostalCode, p.Shop.StreetAddress, p.Shop.City }).ToList();

            var lolcalizationSelectList = new SelectList(localizationList.Select(s => new
            {
                Text = $"Shop: {s.Name}, Country: {s.Country},City: {s.City},Street: {s.StreetAddress},PostalCode: {s.PostalCode}",
                Url = $"User/Home/ProductByShop?productName={productName}&categoryName={categoryName}&subCategoryName={subCategoryName}&shopName={s.Name}&country={s.Country}&city={s.City}&street={s.StreetAddress}&postalCode={s.PostalCode}"
            }), "Url", "Text"); ;

            return Json(lolcalizationSelectList);
        }

        [Authorize(Roles = SD.Admin + ", " + SD.User)]
        public async Task<IActionResult> ProductByShop(string productName = null, string categoryName = null, string subCategoryName = null, string shopName = null, string country = null, string city = null, string street = null, string postalCode = null)
        {
            var productEntity = await _productService.Get(p => p.Name == productName && p.Category.Name == categoryName && p.SubCategory.Name == subCategoryName
                                                            && p.Shop.Name == shopName && p.Shop.Country == country && p.Shop.City == city &&
                                                            p.Shop.StreetAddress == street && p.Shop.PostalCode == postalCode);

            var productDto = new { productEntity.Price, productEntity.AverageGrade, productEntity.Description };

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
