using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportProductsEvaluation.Data;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using SupportProductsEvaluation.Infrastructure.Utility;
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
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            return View(await _userService.GetAll(u => u.Id != claim.Value));
        }

        public async Task<IActionResult> Lock(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            user.LockoutEnd = DateTime.Now.AddYears(1000);
            await _userService.Update(user);

            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> UnLock(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            user.LockoutEnd = DateTime.Now;
            await _userService.Update(user);

            return RedirectToAction(nameof(Index));

        }
    }

}
