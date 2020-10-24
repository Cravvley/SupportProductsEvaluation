using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Compareo.Infrastructure.Pagination;
using Compareo.Infrastructure.Services.Interfaces;
using Compareo.Infrastructure.Utility;
using Compareo.Infrastructure.VMs;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Compareo.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = SD.Admin)]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        private const int PageSize = 10;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index(int productPage = 1, string searchByEmail = null)
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var users = await _userService.GetAll(u => u.Id != claim.Value);

            var userListVM = new UserListVM()
            {
                Users = users.ToList()
            };

            var count = userListVM.Users.Count;

            userListVM.Users = await _userService.GetPaginated(u => u.Id != claim.Value, PageSize, productPage);

            if (!(searchByEmail is null))
            {
                userListVM.Users = await _userService.GetPaginated(u => u.Email.ToLower()
                                      .Contains(searchByEmail.ToLower()) && u.Id != claim.Value, PageSize, productPage);

                count = userListVM.Users.Count;
            }

            const string Url = "/Admin/User/Index?productPage=:";

            userListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                UrlParam = Url
            };

            return View(userListVM);
        }

        public async Task<IActionResult> Lock(string id)
        {
            await _userService.Lock(id, true);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UnLock(string id)
        {
            await _userService.Lock(id, false);

            return RedirectToAction(nameof(Index));
        }
    }

}
