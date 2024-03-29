﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCoffee.Data;
using WebCoffee.Models;
using WebCoffee.Services;
using WebCoffee.ViewModels;

namespace WebCoffee.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private IWebHostEnvironment _hostEnvironment;
        public AdminController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductViewModel model)
        {
            if(ModelState.IsValid)
            {
                var path = "/Files/Images/Products/Photos/";
                var fileService = new FileService();
                await fileService.CreateFile(path, model.Photo.FileName, model.Photo, _hostEnvironment);

                await _context.Files.AddAsync(new FileModel { Name = model.Photo.FileName, Path = path });
                await _context.SaveChangesAsync();

                var photo = await _context.Files.Where(x => x.Path == path && x.Name == model.Photo.FileName).FirstOrDefaultAsync();
                var category = await _context.Categories.Where(x => x.Name == model.Category).FirstOrDefaultAsync();

                if(category == null)
                {
                    await _context.Categories.AddAsync(new Category() { Name = model.Category });
                    await _context.SaveChangesAsync();
                    category = await _context.Categories.Where(x => x.Name == model.Category).FirstOrDefaultAsync();
                }
                await _context.Products.AddAsync(new Product() { Name = model.Name, Price = model.Price, Description = model.Description, Category = category, Photo = photo });
                await _context.SaveChangesAsync();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Menu");
        }
    }
}
