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
        private UserManager<ApplicationUser> _userManager;
        public ApplicationDbContext _context;

        public PurchasesController(ILogger<PurchasesController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(await _context.Orders.Where(x => x.User.Id == user.Id)
                .Include(x => x.User)
                .Include(x => x.Purchases).ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                .Include(x => x.Purchases).ThenInclude(x => x.Product).ThenInclude(x => x.Photo)
                .Include(x => x.Purchases).ThenInclude(x => x.Portion)
                .Include(x => x.Purchases).ThenInclude(x => x.Order).ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> Create(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if(String.IsNullOrEmpty(user.Address) || String.IsNullOrEmpty(user.Phone) ||
                user.Age == 0 || String.IsNullOrEmpty(user.Name) || String.IsNullOrEmpty(user.Surname))
            {
                return RedirectToAction("Index", "Manage");
            }
            var bag = await _context.Bags.Where(x => x.User.Id == user.Id && x.Id == id)
                .Include(x => x.Product).ThenInclude(x => x.Photo)
                .Include(x => x.Product).ThenInclude(x => x.Category)
                .Include(x => x.Portion)
                .Include(x => x.User).FirstOrDefaultAsync();
            if(bag != null)
            {
                var price = bag.Product.Price * bag.Amount;
                var datetime = DateTime.Now;
                await _context.Orders.AddAsync(new Order() { Price = price, Date = datetime.ToShortDateString(), Time = datetime.ToShortTimeString(), User = user });
                await _context.SaveChangesAsync();
                var order = await _context.Orders.Where(x => x.User.Id == user.Id).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                await _context.Purchases.AddAsync(new Purchase() { Amount = bag.Amount, Portion = bag.Portion, Price = price, Product = bag.Product, Order = order });
                _context.Bags.Remove(bag);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> CreateAll()
        {
            var user = await _userManager.GetUserAsync(User);
            if (String.IsNullOrEmpty(user.Address) || String.IsNullOrEmpty(user.Phone) ||
                user.Age == 0 || String.IsNullOrEmpty(user.Name) || String.IsNullOrEmpty(user.Surname))
            {
                return RedirectToAction("Index", "Manage");
            }
            var bag = await _context.Bags.Where(x => x.User.Id == user.Id)
                .Include(x => x.Product).ThenInclude(x => x.Photo)
                .Include(x => x.Product).ThenInclude(x => x.Category)
                .Include(x => x.Portion)
                .Include(x => x.User).ToListAsync();
            if(bag.Count() > 0)
            {
                var datetime = DateTime.Now;
                await _context.Orders.AddAsync(new Order() { Price = 0, Date = datetime.ToShortDateString(), Time = datetime.ToShortTimeString(), User = user });
                await _context.SaveChangesAsync();
                var order = await _context.Orders.Where(x => x.User.Id == user.Id).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                foreach (var item in bag)
                {
                    var price = item.Product.Price * item.Amount;
                    await _context.Purchases.AddAsync(new Purchase() { Amount = item.Amount, Portion = item.Portion, Price = price, Product = item.Product, Order = order });
                    await _context.SaveChangesAsync();
                }
                _context.Bags.RemoveRange(bag);
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
        [Authorize(Roles = "Employee")]
        [HttpGet]
        public async Task<ActionResult> Job()
        {
            var orders = await _context.Orders.Where(x => !x.Completed && !x.Taken)
                .Include(x => x.Purchases).ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                .Include(x => x.Purchases).ThenInclude(x => x.Product).ThenInclude(x => x.Photo)
                .Include(x => x.Purchases).ThenInclude(x => x.Portion)
                .Include(x => x.Purchases).ThenInclude(x => x.Order)
                .Include(x => x.User)
                .ToListAsync();
            return View("Job", orders);
        }
        [Authorize(Roles = "Employee")]
        [HttpPost]
        public async Task<ActionResult> TakeOrder(int id)
        {
            var order = await _context.Orders.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(order != null)
            {
                var employee = await _userManager.GetUserAsync(User);
                var datetime = DateTime.Now;
                order.DateOfTaking = datetime.ToShortDateString();
                order.TimeOfTaking = datetime.ToShortTimeString();
                order.Employee = employee;
                order.Taken = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Job");
        }
        [HttpPost]
        public async Task<ActionResult> AcceptOrder(int id)
        {
            var order = await _context.Orders.Where(x => x.Id == id)
                .Include(x => x.Employee)
                .FirstOrDefaultAsync();
            if (order != null)
            {
                order.Completed = true;
                var employee = await _userManager.FindByIdAsync(order.Employee.Id);
                employee.Rating += 1;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
