using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupportProductsEvaluation.Core.Repositories;
using SupportProductsEvaluation.Infrastructure.VMs;
using System.Diagnostics;

namespace SupportProductsEvaluation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger, IShopRepository shopRepository)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
