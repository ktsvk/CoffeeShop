using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebCoffee.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public ManageController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Profile(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return View(user);
        }
    }
}
