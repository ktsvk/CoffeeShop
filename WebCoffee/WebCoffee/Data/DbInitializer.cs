using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoffee.Models;

namespace WebCoffee.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext context)
        {
            if (!await context.Categories.AnyAsync())
            {
                await context.Categories.AddRangeAsync(
                    new Category() { Name = "Кофе", NormalizedName = "coffee" },
                    new Category() { Name = "Бургер", NormalizedName = "burger" },
                    new Category() { Name = "Пончик", NormalizedName = "donut" });
                await context.SaveChangesAsync();
            }
            if(!await context.Files.AnyAsync())
            {
                await context.Files.AddRangeAsync(
                    new FileModel() { Name = "espresso.jpg", Path = "/Files/Images/" },
                    new FileModel() { Name = "capuchino.jpg", Path = "/Files/Images/" },
                    new FileModel() { Name = "americano.jpg", Path = "/Files/Images/" },
                    new FileModel() { Name = "latte.jpg", Path = "/Files/Images/" });
                await context.SaveChangesAsync();
            }
            if (!await context.Products.AnyAsync())
            {
                var categories = await context.Categories.ToListAsync();
                var files = await context.Files.ToListAsync();
                await context.Products.AddRangeAsync(
                    new Product() { Name = "Эспрессо", Price = 2.2f, Photo = files.Where(x => x.Name == "espresso.jpg").FirstOrDefault(), Category = categories.FirstOrDefault(x => x.Name == "Кофе"), Description = "Напиток приготовленный с помощью рожковой эспрессо-машины. Принципиальные различия во вкусе достигаются благодаря более длительному времени экстракции, за которое в чашку (крое эфирных масел) попадает и большее количество кофеина." },
                    new Product() { Name = "Капучино", Price = 2.8f, Photo = files.Where(x => x.Name == "capuchino.jpg").FirstOrDefault(), Category = categories.FirstOrDefault(x => x.Name == "Кофе"), Description = "Эспрессо со вспененным молоком. Название происходит от ит. слова “капуцин” – отсылка к характерному красно-коричневому цвету роб у монашеского ордена капуцинов. В отличие от латте, подается, как и эспрессо, в предварительно прогретой кофейной чашке на 150–180 мл. Если сравнивать латте и капучино – молока больше в латте, о нём дальше." },
                    new Product() { Name = "Американо", Price = 2.7f, Photo = files.Where(x => x.Name == "americano.jpg").FirstOrDefault(), Category = categories.FirstOrDefault(x => x.Name == "Кофе"), Description = "Эспрессо обычный или двойной, в который после приготовления добавили (30–470 мл) горячей воды. Крепость зависит от количества шотов эспрессо. В Италии и Франции даже не пытайтесь просить Американо, вам принесут лунго." },
                    new Product() { Name = "Латте", Price = 2.8f, Photo = files.Where(x => x.Name == "latte.jpg").FirstOrDefault(), Category = categories.FirstOrDefault(x => x.Name == "Кофе"), Description = "Международный напиток из эспрессо со вспененным молоком. В 240 мл стакан добавляют шот эспрессо, который заливают молоком с молочной пенкой. Толщина пенки 12мм. В отличие от капучино, в латте кроме пенки есть еще и слой молока. Будьте внимательн, когда заказываете напиток в Европе. Сказав просто “Латте” – в Италии вам подадут молоко, во Франции – кофе с молоком." });
                await context.SaveChangesAsync();
            }
            if (!await context.Purchases.AnyAsync())
            {
                var products = await context.Products.ToListAsync();
                var users = await context.Users.ToListAsync();
                await context.Purchases.AddRangeAsync(
                    new Purchase() { Product = products.FirstOrDefault(x => x.Id == 1), User = users.FirstOrDefault(), Amount = 1, Date = "11.10.2020", Time = "13:50" },
                    new Purchase() { Product = products.FirstOrDefault(x => x.Id == 2), User = users.FirstOrDefault(), Amount = 2, Date = "11.10.2020", Time = "13:54" },
                    new Purchase() { Product = products.FirstOrDefault(x => x.Id == 4), User = users.FirstOrDefault(), Amount = 2, Date = "11.10.2020", Time = "13:57" },
                    new Purchase() { Product = products.FirstOrDefault(x => x.Id == 3), User = users.FirstOrDefault(), Amount = 1, Date = "11.10.2020", Time = "13:59" },
                    new Purchase() { Product = products.FirstOrDefault(x => x.Id == 2), User = users.FirstOrDefault(), Amount = 4, Date = "11.10.2020", Time = "14:01" },
                    new Purchase() { Product = products.FirstOrDefault(x => x.Id == 1), User = users.FirstOrDefault(), Amount = 3, Date = "11.10.2020", Time = "14:10" }
                    );
                await context.SaveChangesAsync();
            }
        }
    }
}
