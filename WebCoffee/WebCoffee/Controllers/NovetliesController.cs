using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoffee.Data;
using WebCoffee.Models;
using WebCoffee.ViewModels.Novetlies;

namespace WebCoffee.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NovetliesController : Controller
    {
        private ApplicationDbContext _context;
        public NovetliesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var news = await _context.News.OrderByDescending(x => x.Id).ToListAsync();
            return View(news);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateNewsViewModel model)
        {
            if(ModelState.IsValid)
            {
                var datetime = DateTime.Now;
                await _context.News.AddAsync(new Novetly { Title = model.Title, Body = model.Body, Date = datetime.ToShortDateString(), Time = datetime.ToShortTimeString() });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
