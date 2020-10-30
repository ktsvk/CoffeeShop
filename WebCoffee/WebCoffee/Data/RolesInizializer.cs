using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoffee.Models;

namespace WebCoffee.Data
{
    public class RolesInizializer
    {
        public static async Task InizializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            string email = "admin@mail.ru";
            string password = "admin";

            string userEmail = "user@mail.ru";
            string userPassword = "user";

            var photo = await context.Files.Where(x => x.Name == "default.png" && x.Path == "/Files/Images/Users/").FirstOrDefaultAsync();

            if (await roleManager.FindByNameAsync("Admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (await roleManager.FindByNameAsync("User") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
            if (await userManager.FindByNameAsync(userEmail) == null)
            {
                var user = new ApplicationUser { Email = userEmail, UserName = userEmail, Photo = photo };
                var result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                }
            }
            if (await userManager.FindByNameAsync(email) == null)
            {
                var admin = new ApplicationUser { Email = email, UserName = email, Photo = photo };
                var result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
