using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoffee.Data
{
    public class RolesInizializer
    {
        public static async Task InizializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string email = "admin@mail.ru";
            string password = "_Admin123";

            string userEmail = "user@mail.ru";
            string userPassword = "_User123";
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
                var user = new IdentityUser { Email = userEmail, UserName = userEmail };
                var result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                }
            }
            if (await userManager.FindByNameAsync(email) == null)
            {
                var admin = new IdentityUser { Email = email, UserName = email };
                var result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
