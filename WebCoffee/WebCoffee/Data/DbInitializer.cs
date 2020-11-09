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
            if(!await context.Portions.AnyAsync())
            {
                await context.Portions.AddRangeAsync(
                    new Portion { Name = "Маленькая", Size = 100, Multiplier = 1},
                    new Portion { Name = "Средняя", Size = 200, Multiplier = 1.5f },
                    new Portion { Name = "Большая", Size = 300, Multiplier = 2.5f });
                await context.SaveChangesAsync();
            }
            if (!await context.Categories.AnyAsync())
            {
                await context.Categories.AddRangeAsync(
                    new Category() { Name = "Кофе" },
                    new Category() { Name = "Чай" },
                    new Category() { Name = "Пироженое" },
                    new Category() { Name = "Торт" },
                    new Category() { Name = "Печенье" });
                await context.SaveChangesAsync();
            }
            if(!await context.Files.AnyAsync())
            {
                await context.Files.AddRangeAsync(
                    new FileModel() { Name = "espresso.jpg", Path = "/Files/Images/" },
                    new FileModel() { Name = "capuchino.jpg", Path = "/Files/Images/" },
                    new FileModel() { Name = "americano.jpg", Path = "/Files/Images/" },
                    new FileModel() { Name = "latte.jpg", Path = "/Files/Images/" },
                    new FileModel() { Name = "coffemoloko.jpg", Path = "/Files/Images/" },
                    new FileModel() { Name = "creamcoffee.jpg", Path = "/Files/Images/" },
                    new FileModel() { Name = "frappe.jpg", Path = "/Files/Images/" },
                    new FileModel() { Name = "lungo.jpg", Path = "/Files/Images/" },
                    new FileModel() { Name = "makiato.jpg", Path = "/Files/Images/" },
                    new FileModel() { Name = "tureckicoffee.jpg", Path = "/Files/Images/" },
                    new FileModel() { Name = "yuanyan.jpg", Path = "/Files/Images/" },
                    new FileModel() { Name = "coffeeirlandski.jpg", Path = "/Files/Images/" },
                    new FileModel() { Name = "coffeice.jpg", Path = "/Files/Images/" },
                    new FileModel() { Name = "default.png", Path = "/Files/Images/Users/" });
                await context.SaveChangesAsync();
            }
            if (!await context.Products.AnyAsync())
            {
                var categories = await context.Categories.ToListAsync();
                var photos = await context.Files.ToListAsync();
                await context.Products.AddRangeAsync(
                    new Product() { Name = "Эспрессо", Price = 2.2f, Photo = photos.Where(x => x.Name == "espresso.jpg").FirstOrDefault(), Category = categories.FirstOrDefault(x => x.Name == "Кофе"), Description = "Напиток приготовленный с помощью рожковой эспрессо-машины. Принципиальные различия во вкусе достигаются благодаря более длительному времени экстракции, за которое в чашку (крое эфирных масел) попадает и большее количество кофеина." },
                    new Product() { Name = "Капучино", Price = 2.8f, Photo = photos.Where(x => x.Name == "capuchino.jpg").FirstOrDefault(), Category = categories.FirstOrDefault(x => x.Name == "Кофе"), Description = "Эспрессо со вспененным молоком. Название происходит от ит. слова “капуцин” – отсылка к характерному красно-коричневому цвету роб у монашеского ордена капуцинов. В отличие от латте, подается, как и эспрессо, в предварительно прогретой кофейной чашке на 150–180 мл. Если сравнивать латте и капучино – молока больше в латте, о нём дальше." },
                    new Product() { Name = "Американо", Price = 2.7f, Photo = photos.Where(x => x.Name == "americano.jpg").FirstOrDefault(), Category = categories.FirstOrDefault(x => x.Name == "Кофе"), Description = "Эспрессо обычный или двойной, в который после приготовления добавили (30–470 мл) горячей воды. Крепость зависит от количества шотов эспрессо. В Италии и Франции даже не пытайтесь просить Американо, вам принесут лунго." },
                    new Product() { Name = "Кофе по-ирландски", Price = 2.2f, Photo = photos.Where(x => x.Name == "coffeeirlandski.jpg").FirstOrDefault(), Category = categories.FirstOrDefault(x => x.Name == "Кофе"), Description = "" },
                    new Product() { Name = "Кофе со льдом", Price = 1.8f, Photo = photos.Where(x => x.Name == "coffeice.jpg").FirstOrDefault(), Category = categories.FirstOrDefault(x => x.Name == "Кофе"), Description = "" },
                    new Product() { Name = "Кофе с молоком", Price = 2f, Photo = photos.Where(x => x.Name == "coffemoloko.jpg").FirstOrDefault(), Category = categories.FirstOrDefault(x => x.Name == "Кофе"), Description = "" },
                    new Product() { Name = "Крем кофе", Price = 2.5f, Photo = photos.Where(x => x.Name == "creamcoffee.jpg").FirstOrDefault(), Category = categories.FirstOrDefault(x => x.Name == "Кофе"), Description = "" },
                    new Product() { Name = "Фраппе", Price = 2.8f, Photo = photos.Where(x => x.Name == "frappe.jpg").FirstOrDefault(), Category = categories.FirstOrDefault(x => x.Name == "Кофе"), Description = "" },
                    new Product() { Name = "Лунго", Price = 2.7f, Photo = photos.Where(x => x.Name == "lungo.jpg").FirstOrDefault(), Category = categories.FirstOrDefault(x => x.Name == "Кофе"), Description = "" },
                    new Product() { Name = "Макиато", Price = 2.9f, Photo = photos.Where(x => x.Name == "makiato.jpg").FirstOrDefault(), Category = categories.FirstOrDefault(x => x.Name == "Кофе"), Description = "" },
                    new Product() { Name = "Кофе по-турецки", Price = 2.2f, Photo = photos.Where(x => x.Name == "tureckicoffee.jpg").FirstOrDefault(), Category = categories.FirstOrDefault(x => x.Name == "Кофе"), Description = "" },
                    new Product() { Name = "Кофе янь-янь", Price = 2.2f, Photo = photos.Where(x => x.Name == "yuanyan.jpg").FirstOrDefault(), Category = categories.FirstOrDefault(x => x.Name == "Кофе"), Description = "" },
                    new Product() { Name = "Латте", Price = 2.8f, Photo = photos.Where(x => x.Name == "latte.jpg").FirstOrDefault(), Category = categories.FirstOrDefault(x => x.Name == "Кофе"), Description = "Международный напиток из эспрессо со вспененным молоком. В 240 мл стакан добавляют шот эспрессо, который заливают молоком с молочной пенкой. Толщина пенки 12мм. В отличие от капучино, в латте кроме пенки есть еще и слой молока. Будьте внимательн, когда заказываете напиток в Европе. Сказав просто “Латте” – в Италии вам подадут молоко, во Франции – кофе с молоком." });
                await context.SaveChangesAsync();
            }
        }
    }
}
