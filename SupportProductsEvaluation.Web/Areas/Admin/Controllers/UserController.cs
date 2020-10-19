using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupportProductsEvaluation.Infrastructure.Pagination;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using SupportProductsEvaluation.Infrastructure.Utility;
using SupportProductsEvaluation.Infrastructure.VMs;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.Admin)]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        private const int PageSize = 10;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index(int productPage = 1, string searchEmail = null)
        {

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var users = await _userService.GetAll(u => u.Id != claim.Value);
            UserListVM userListVM = new UserListVM()
            {
                Users = users.ToList()
            };

            if (searchEmail != null)
            {
                userListVM.Users = userListVM.Users.Where(s => s.Email.ToLower()
                                     .Contains(searchEmail.ToLower())).OrderByDescending(o => o.Name)
                                     .ToList();
            }

            var count = userListVM.Users.Count;
            userListVM.Users = userListVM.Users.OrderByDescending(p => p.Id)
                                     .Skip((productPage - 1) * PageSize)
                                     .Take(PageSize).ToList();

            userListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                urlParam = "/User/Home/Index?productPage=:"
            };

            return View(userListVM);
        }

        public async Task<IActionResult> Lock(string id)
        {
            var user = await _userService.Get(id);

            user.LockoutEnd = DateTime.Now.AddYears(1000);
            await _userService.Update(user);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UnLock(string id)
        {
            var user = await _userService.Get(id);

            user.LockoutEnd = DateTime.Now;
            await _userService.Update(user);

            return RedirectToAction(nameof(Index));

        }
    }

}
