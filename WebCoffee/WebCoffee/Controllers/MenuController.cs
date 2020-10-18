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

        public ActionResult Index(int? category)
        {
            if (category != null && category > 0)
            {
                return View(_context.Products.Where(x => x.Category.Id == category).Include(x => x.Photo).Include(p => p.Category).ToList());
            }
            return View(_context.Products.Include(x => x.Photo).Include(p => p.Category).ToList());
        }
        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(x => x.Id == id).Include(x => x.Photo).Include(x => x.Category).FirstOrDefault());
        }
    }
}
