using Compareo.Data.Entities;
using Compareo.Infrastructure.Common.Pagination;
using Compareo.Infrastructure.Common.StaticFiles;
using Compareo.Infrastructure.Services.Interfaces;
using Compareo.Infrastructure.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Compareo.Web.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IReportService _reportService;
        private readonly IRateService _rateService;
        private readonly ICommentService _commentService;
        private readonly IShopPropositionService _shopPropositionService;
        private readonly IProductPropositionService _productPropositionService;
        private readonly IShopService _shopService;

        private const int PageSize = 9;
        public HomeController(IProductService productService, IReportService reportService, IRateService rateService,
            ICommentService commentService, IShopPropositionService shopPropositionService, IProductPropositionService productPropositionService,
            IShopService shopService)
        {
            _productService = productService;
            _reportService = reportService;
            _rateService = rateService;
            _commentService = commentService;
            _shopPropositionService = shopPropositionService;
            _productPropositionService = productPropositionService;
            _shopService = shopService;
        }

        public async Task<IActionResult> Index(int productPage = 1, string searchByProduct = null, string searchByCategory = null, string searchByShop = null)
        {
            var (products, productsCount) = await _productService.GetFiltered(searchByProduct, searchByCategory, searchByShop,PageSize,productPage);

            var homeVM = new HomeVM()
            {
                Products = products,
                ProductProposition = new ProductProposition(),
                ShopProposition = new ShopProposition()
            };

            const string Url = "/User/Home/Index?productPage=:";

            homeVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = productsCount,
                UrlParam = Url
            };

            var shops = await _shopService.GetAllHeaders();

            ViewBag.ShopsSelectList = new SelectList(shops.Select(p => new
            {
                Text = $"Shop: {p.Name}, {p.City} {p.StreetAddress} {p.PostalCode}",
                p.Id
            }), "Id", "Text");

            return View(homeVM);
        }

        [Authorize(Roles = Constants.Admin + ", " + Constants.User)]
        public async Task<IActionResult> Reports(int productPage = 1, string searchByProduct = null, string searchByCategory = null)
        {
            var (reports, reportsCount) = await _reportService.GetFiltered(searchByProduct, searchByCategory, PageSize, productPage);

            var reportListVM = new ReportListVM()
            {
                Reports = reports
            };

            const string Url = "/User/Home/Reports?productPage=:";

            reportListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = reportsCount,
                UrlParam = Url
            };

            return View(reportListVM);
        }

        [Authorize(Roles = Constants.Admin + ", " + Constants.User)]
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

            productDetailsVM.Product.Comments = await _commentService.GetPaginated(x => x.ProductId == id, PageSize, productPage);

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

        [Authorize(Roles = Constants.Admin + ", " + Constants.User), HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> AddComentToProduct(Comment comment)
        {
            await _commentService.Add(comment);

            return RedirectToAction("ProductDetails", new { Id = comment.ProductId });
        }

        [Authorize(Roles = Constants.Admin + ", " + Constants.User), HttpPost, ValidateAntiForgeryToken]
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

        [Authorize(Roles = Constants.Admin + ", " + Constants.User)]
        public async Task<IActionResult> ReportDetails(int? id)
                    => Json(await _reportService.Get(id));

        [Authorize(Roles = Constants.Admin + ", " + Constants.User)]
        public async Task<IActionResult> Comparison()
        {
            var productEntities = await _productService.GetAllHeaders();

            var uniqueProducts = productEntities.Select(x => new { ProductName = x.Name, CategoryName = x.Category.Name, x.CategoryId })
                                                .Distinct();

            ViewBag.ProductsSelectList = new SelectList(uniqueProducts.Select(p => new
            {
                Text = $"Product: {p.ProductName}, Category: {p.CategoryName}",
                Url = $"User/Home/ProductsLocalization?productName={p.ProductName}&categoryId={p.CategoryId}"
            }), "Url", "Text");

            return View();
        }

        [Authorize(Roles = Constants.Admin + ", " + Constants.User)]
        public async Task<IActionResult> ProductsLocalization(string productName = null, int? categoryId = null)
        {
            var products = await _productService.GetAllHeaders();

            var localizationList = products.Where(x => x.Name.ToLower() == productName.ToLower() && x.Category.Id == categoryId)
                                            .Select(p => new { p.Shop.Name, p.Shop.Country, p.Shop.PostalCode, p.Shop.StreetAddress, p.Shop.City }).ToList();

            var lolcalizationSelectList = new SelectList(localizationList.Select(s => new
            {
                Text = $"Shop: {s.Name}, Country: {s.Country},City: {s.City},Street: {s.StreetAddress},PostalCode: {s.PostalCode}",
                Url = $"User/Home/ProductByShop?productName={productName}&categoryId={categoryId}&shopName={s.Name}&country={s.Country}&city={s.City}&street={s.StreetAddress}&postalCode={s.PostalCode}"
            }), "Url", "Text"); ;

            return Json(lolcalizationSelectList);
        }

        [Authorize(Roles = Constants.Admin + ", " + Constants.User)]
        public async Task<IActionResult> ProductByShop(string productName = null, int? categoryId = null, string shopName = null, string country = null, string city = null, string street = null, string postalCode = null)
        {
            var productEntity = await _productService.Get(p => p.Name.ToLower() == productName.ToLower() && p.Category.Id == categoryId
                                                            && p.Shop.Name.ToLower() == shopName.ToLower() && p.Shop.Country.ToLower() == country.ToLower() && p.Shop.City.ToLower() == city.ToLower()
                                                            && p.Shop.StreetAddress.ToLower() == street.ToLower() && p.Shop.PostalCode.ToLower() == postalCode.ToLower());

            var productDto = new { productEntity.Price, productEntity.AverageGrade, productEntity.Description };

            return Json(productDto);
        }

        [Authorize(Roles = Constants.Admin + ", " + Constants.User), HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductProposition(ProductProposition productProposition)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            productProposition.UserId = claim.Value;

            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0)
            {
                byte[] p1 = null;
                using (var fs1 = files[0].OpenReadStream())
                {
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                }
                productProposition.Picture = p1;
            }
            else
            {
                byte[] p1 = { 0 };
                productProposition.Picture = p1;
            }

            await _productPropositionService.Create(productProposition);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = Constants.Admin + ", " + Constants.User), HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ShopProposition(ShopProposition shopProposition)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            shopProposition.UserId = claim.Value;

            await _shopPropositionService.Create(shopProposition);

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
