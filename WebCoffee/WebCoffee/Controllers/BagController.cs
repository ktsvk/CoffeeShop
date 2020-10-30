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
        public async Task<ActionResult> Create(int id, int portion, int amount)//fix если такой продукт уже есть в корзине
        {
            if(amount == 0)
            {
                return RedirectToAction("Index");
            }
            var product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(product != null)
            {
                var user = await _userManager.GetUserAsync(User);
                var _portion = await _context.Portions.Where(x => x.Size == portion).FirstOrDefaultAsync();
                await _context.Bags.AddAsync(new Bag() { Amount = amount, Portion = _portion, Product = product, User = user } );
                await _context.SaveChangesAsync();

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
