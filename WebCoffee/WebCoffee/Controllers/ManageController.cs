using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCoffee.Data;
using WebCoffee.Models;
using WebCoffee.ViewModels;

namespace WebCoffee.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ApplicationDbContext _context;
        private IWebHostEnvironment _hostEnvironment;

        public ManageController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context,
            IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public async Task<ActionResult> Index(string id)
        {
            if(id == null)
            {
                var identityUser = await _userManager.GetUserAsync(User);
                var user = await _context.Users.Where(x => x.Id == identityUser.Id).Include(x => x.Photo).FirstOrDefaultAsync();
                if (user != null)
                    return View(user);
            }
            else
            {
                var identityUser = await _userManager.FindByIdAsync(id);
                var user = await _context.Users.Where(x => x.Id == identityUser.Id).Include(x => x.Photo).FirstOrDefaultAsync();
                if(user != null)
                {
                    var model = new ProfileViewModel();
                    model.User = user;
                    model.NotificationsCount = _context.Notifications.Where(x => x.To.Id == user.Id).Count();
                    model.Orders = await _context.Orders.Where(x => x.User.Id == user.Id)
                        .Include(x => x.User)
                        .Include(x => x.Purchases).ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                        .Include(x => x.Purchases).ThenInclude(x => x.Product).ThenInclude(x => x.Photo)
                        .Include(x => x.Purchases).ThenInclude(x => x.Portion)
                        .Include(x => x.Purchases).ThenInclude(x => x.Order)
                        .OrderByDescending(x => x.Id)
                        .ToListAsync();
                    return View(model);
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<ActionResult> ChangeInfo(ChangeInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Age = model.Age;
                user.Phone = model.Phone;
                user.Address = model.Address;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> ChangePhoto(IFormFile photo)
        {
            if(photo != null)
            {
                var identityUser = await _userManager.GetUserAsync(User);
                string path = "/Files/Images/Users/Photos/" + photo.FileName;

                using (var fs = new FileStream(_hostEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await photo.CopyToAsync(fs);
                }
                FileModel file = new FileModel { Name = photo.FileName, Path = "/Files/Images/Users/Photos/" };
                await _context.Files.AddAsync(file);
                await _context.SaveChangesAsync();
                var temp = await _context.Files.Where(x => x.Path == file.Path && x.Name == file.Name).FirstOrDefaultAsync();
                identityUser.Photo = temp;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
