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
using WebCoffee.ViewModels;

namespace WebCoffee.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> Index(int? category, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<Product> products = _context.Products
                .Include(x => x.Category)
                .Include(x => x.Photo);

            if (category != null && category != 0)
            {
                products = products.Where(p => p.Category.Id == category);
            }
            if (!String.IsNullOrEmpty(name))
            {
                products = products.Where(p => p.Name.Contains(name));
            }

            int pageSize = 10;

            switch (sortOrder)
            {
                case SortState.NameDesc:
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case SortState.PriceAsc:
                    products = products.OrderBy(s => s.Price);
                    break;
                case SortState.PriceDesc:
                    products = products.OrderByDescending(s => s.Price);
                    break;
                case SortState.PurchasesAsc:
                    products = products.OrderBy(s => s.PurchaseCount);
                    break;
                case SortState.PurchasesDesc:
                    products = products.OrderByDescending(s => s.PurchaseCount);
                    break;
                case SortState.CategoryAsc:
                    products = products.OrderBy(s => s.Category.Name);
                    break;
                case SortState.CategoryDesc:
                    products = products.OrderByDescending(s => s.Category.Name);
                    break;
                default:
                    products = products.OrderBy(s => s.Name);
                    break;
            }

            var count = await products.CountAsync();
            var items = await products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            MenuViewModel viewModel = new MenuViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(_context.Categories.ToList(), category, name),
                Products = items
            };
            return View(viewModel);
        }
        [HttpGet]
        public async Task<ActionResult> Details(int id) => 
            View(await _context.Products.Where(x => x.Id == id)
                .Include(x => x.Category)
                .Include(x => x.Photo)
                .FirstOrDefaultAsync());
    }
}
