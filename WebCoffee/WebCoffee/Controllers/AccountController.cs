using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCoffee.Data;
using WebCoffee.Models;
using WebCoffee.Services;
using WebCoffee.ViewModels;

namespace WebCoffee.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ApplicationDbContext _context;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var photo = await _context.Files.Where(x => x.Name == "default.png" && x.Path == "/Files/Images/Users/").FirstOrDefaultAsync();

                ApplicationUser user = new ApplicationUser { UserName = model.Username, Photo =  photo };

                var result = await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if(user != null)
                {
                    if (user.Banned)
                        return View(model);
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe = false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Неправильный логин или пароль");
                    }
                }
                else
                    ModelState.AddModelError(string.Empty, "Неправильный логин или пароль");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
