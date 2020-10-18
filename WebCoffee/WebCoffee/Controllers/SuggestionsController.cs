using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class SuggestionsController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        IWebHostEnvironment _webHostEnvironment;
        public SuggestionsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(_context.Suggestions.Where(x => x.User.Id == user.Id).Include(x => x.User).Include(x => x.Photo).ToList());
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View(_context.Suggestions.Include(x => x.User).Include(x => x.Photo).ToList());
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Confirm(int id, string NormalizedCategory)
        {
            var suggestion = _context.Suggestions.Where(x => x.Id == id).Include(x => x.User).Include(x => x.Photo).FirstOrDefault();
            if(suggestion != null)
            {
                var product = _context.Products.Where(x => x.Name == suggestion.Name && x.Category.Name == suggestion.Category).FirstOrDefault();
                if(product != null)
                {
                    return RedirectToAction("Admin");
                }
                var user = suggestion.User;
                var admin = await _userManager.GetUserAsync(User);
                var category = await _context.Categories.Where(x => x.Name == suggestion.Category).FirstOrDefaultAsync();
                if(category == null)
                {
                    await _context.Categories.AddAsync(new Category() { Name = suggestion.Category, NormalizedName = NormalizedCategory });
                    await _context.SaveChangesAsync();
                    category = _context.Categories.Where(x => x.Name == suggestion.Category).FirstOrDefault();
                }
                await _context.Notifications.AddAsync(new Notification() { Message = $"Продукт: {suggestion.Category} \"{suggestion.Name}\" был принят администратором: {admin.Email}! ", To = user, From = admin, Status = false, Date = DateTime.Now.ToShortDateString(), Time = DateTime.Now.ToShortTimeString() });
                await _context.Products.AddAsync(new Product() { Name = suggestion.Name, Photo = suggestion.Photo, Price = suggestion.Price, Description = suggestion.Description, Category = category });
                _context.Suggestions.Remove(suggestion);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Admin");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Refuse(int id, string Message)
        {
            var suggestion = _context.Suggestions.Where(x => x.Id == id).Include(x => x.User).FirstOrDefault();
            if(suggestion != null)
            {
                var user = suggestion.User;
                var admin = await _userManager.GetUserAsync(User);
                var message = $"Отказано в добавлении продукта: {suggestion.Name} администратором: {admin.Email}!";
                Message = Message == "" ? message : message + "\n\n" + Message;
                await _context.Notifications.AddAsync(new Notification() { Message = Message, To = user, From = admin, Status = false, Date = DateTime.Now.ToShortDateString(), Time = DateTime.Now.ToShortTimeString() });
                _context.Suggestions.Remove(suggestion);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Admin");
        }
        [HttpPost]
        public async Task<ActionResult> Create(SuggestionViewModel model)
        {
            if(ModelState.IsValid)
            {
                var product = _context.Products.Where(x => x.Name == model.Name && x.Category.Name == model.Category).FirstOrDefault();
                if (product == null)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var path = "/Files/Images/" + model.Photo.FileName;
                    using (var fs = new FileStream(_webHostEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await model.Photo.CopyToAsync(fs);
                    }
                    await _context.Files.AddAsync(new FileModel { Name = model.Photo.FileName, Path = "/Files/Images/" });
                    await _context.SaveChangesAsync();
                    var file = _context.Files.Where(x => x.Name == model.Photo.FileName && x.Path == "/Files/Images/").FirstOrDefault();
                    await _context.Suggestions.AddAsync(new Suggestion
                    {
                        Name = model.Name,
                        Price = model.Price,
                        Photo = file,
                        Description = model.Description,
                        Category = model.Category,
                        Date = DateTime.Now.ToShortDateString(),
                        Time = DateTime.Now.ToShortTimeString(),
                        User = user
                    });
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erorr");
            }
            return RedirectToAction("Index");
        }
    }
}
