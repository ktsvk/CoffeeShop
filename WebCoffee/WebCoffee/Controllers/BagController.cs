using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCoffee.Data;
using WebCoffee.Models;
using WebCoffee.ViewModels.Products;

namespace WebCoffee.Controllers
{
    [Authorize]
    public class BagController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        public BagController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(await _context.Bags.Where(x => x.User.Id == user.Id)
                .Include(x => x.User)
                .Include(x => x.Portion)
                .Include(x => x.Product).ThenInclude(x => x.Category)
                .Include(x => x.Product).ThenInclude(x => x.Photo).ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateBagItemViewModel model)
        {
            if(ModelState.IsValid)
            {
                var product = await _context.Products.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (product != null)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var bagItem = await _context.Bags.Where(x => x.Product.Id == product.Id && x.Portion.Size == model.Portion && x.User.Id == user.Id)
                        .FirstOrDefaultAsync();
                    if(bagItem != null)
                        bagItem.Amount += model.Amount;
                    else
                    {
                        var portion = await _context.Portions.Where(x => x.Size == model.Portion).FirstOrDefaultAsync();
                        if(portion != null)
                            await _context.Bags.AddAsync(new Bag() { Amount = model.Amount, Portion = portion, Product = product, User = user });
                    }
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var bag = _context.Bags.Where(x => x.User.Id == user.Id);
            var product = await bag.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(product != null)
            {
                _context.Bags.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> DeleteAll(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var bag = _context.Bags.Where(x => x.User.Id == user.Id);
            if (await bag.CountAsync() > 0)
            {
                _context.Bags.RemoveRange(bag);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
