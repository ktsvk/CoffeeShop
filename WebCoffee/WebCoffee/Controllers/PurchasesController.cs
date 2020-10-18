using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebCoffee.Data;
using WebCoffee.Models;

namespace WebCoffee.Controllers
{
    [Authorize]
    public class PurchasesController : Controller
    {
        private ILogger<PurchasesController> _logger;
        private UserManager<IdentityUser> _userManager;
        public ApplicationDbContext _context;

        public PurchasesController(ILogger<PurchasesController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(_context.Purchases.Where(x => x.User.Id == user.Id).Include(x => x.User).Include(p => p.Product).ThenInclude(x => x.Photo).Include(x => x.Product).ThenInclude(p => p.Category).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> Create(int id, int amount)
        {
            var product = _context.Products.Where(x => x.Id == id).FirstOrDefault();
            if(product != null && amount > 0)
            {
                var user = await _userManager.GetUserAsync(User);
                await _context.Purchases.AddAsync(new Purchase() { Amount = amount, Date = DateTime.Now.ToShortDateString(), Time = DateTime.Now.ToShortTimeString(), Product = product, User = user  });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var purchase = _context.Purchases.Where(x => x.Id == id).FirstOrDefault();
            if (purchase != null)
            {
                _context.Purchases.Remove(purchase);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
