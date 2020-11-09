using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebCoffee.Models;

namespace WebCoffee.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Bag> Bags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Portion> Portions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<Notification> Notifications { get; set; }

    }
}
