using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoffee.Data;

namespace WebCoffee.Controllers
{
    public class ReportController : Controller
    {
        private ApplicationDbContext _context;
        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            var report = await _context.Orders
                .Include(x => x.User)
                .Include(x => x.Purchases).ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                .Include(x => x.Purchases).ThenInclude(x => x.Product).ThenInclude(x => x.Photo)
                .Include(x => x.Purchases).ThenInclude(x => x.Portion)
                .Include(x => x.Purchases).ThenInclude(x => x.Order).ToListAsync();
            return View(report);
        }
    }
}
