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
using WebCoffee.ViewModels.Users;

namespace WebCoffee.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var myself = await _userManager.GetUserAsync(User);
            return View(_context.Users.Where(x => x.Id != myself.Id).Include(x => x.Photo).AsAsyncEnumerable());
        }
        [HttpPost]
        public async Task<ActionResult> Ban(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                user.Banned = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> Unban(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Banned = false;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> SetEmoloyee(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(await _userManager.IsInRoleAsync(user, "Employee"))
            {
                await _userManager.RemoveFromRoleAsync(user, "Employee");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Employee");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> SendMessage(string id, string message)
        {
            var from = await _userManager.GetUserAsync(User);
            var to = await _userManager.FindByIdAsync(id);
            if(from != null && to != null && message != "")
            {
                var datetime = DateTime.Now;
                await _context.Notifications.AddAsync(new Notification() { Date = datetime.ToShortDateString(), Time = datetime.ToShortTimeString(), From = from, To = to, Status = false, Message = message  });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateEmployee(CreateEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Age = model.Age,
                    Address = model.Address,
                    Phone = model.Phone
                };
                //_userManager.CreateAsync();
            }
            return View(model);
        }
    }
}
