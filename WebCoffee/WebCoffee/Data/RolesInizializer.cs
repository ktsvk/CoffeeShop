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
            string login = "admin";
            string password = "admin";

            string userlogin = "user";
            string userPassword = "user";

            string employeelogin = "employee";
            string employeePassword = "employee";

            var photo = await context.Files.Where(x => x.Name == "default.png" && x.Path == "/Files/Images/Users/").FirstOrDefaultAsync();

            if (await roleManager.FindByNameAsync("Admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (await roleManager.FindByNameAsync("User") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
            if (await roleManager.FindByNameAsync("Employee") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Employee"));
            }
            if (await userManager.FindByEmailAsync(login) == null)
            {
                var admin = new ApplicationUser { UserName = login, Photo = photo };
                var result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
            if (await userManager.FindByEmailAsync(userlogin) == null)
            {
                var user = new ApplicationUser { UserName = userlogin, Photo = photo };
                var result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                }
            }
            if (await userManager.FindByEmailAsync(employeelogin) == null)
            {
                var employee = new ApplicationUser { UserName = employeelogin, Photo = photo };
                var result = await userManager.CreateAsync(employee, employeePassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(employee, "Employee");
                }
            }
        }
    }
}
