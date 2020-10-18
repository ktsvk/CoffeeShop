using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebCoffee.Data;

namespace WebCoffee.Controllers
{
    [Authorize]
    public class NotificationsController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private ApplicationDbContext _context;

        public NotificationsController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(_context.Notifications.Where(x => x.To.Id == user.Id).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> Check(int id)
        {
            var notification = _context.Notifications.Where(x => x.Id == id).FirstOrDefault();
            if(notification != null)
            {
                notification.Status = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
