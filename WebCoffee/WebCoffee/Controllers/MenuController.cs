using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using WebCoffee.Data;
using WebCoffee.Models;

namespace WebCoffee.Controllers
{
    public class MenuController : Controller
    {
        private readonly ILogger<MenuController> _logger;
        private ApplicationDbContext _context;

        public MenuController(ILogger<MenuController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> Index(int? category)
        {
            if (category != null && category > 0)
            {
                return View(await _context.Products.Where(x => x.Category.Id == category)
                    .Include(x => x.Category)
                    .Include(x => x.Photo).ToListAsync());
            }
            return View(await _context.Products
                    .Include(x => x.Category)
                    .Include(x => x.Photo).ToListAsync());
        }
        public async Task<ActionResult> Details(int id)
        {
            return View(await _context.Products.Where(x => x.Id == id)
                .Include(x => x.Category)
                .Include(x => x.Photo)
                .FirstOrDefaultAsync());
        }
    }
}
