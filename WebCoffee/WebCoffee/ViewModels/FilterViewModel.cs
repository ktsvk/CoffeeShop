using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoffee.Models;

namespace WebCoffee.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Category> categories, int? category, string name)
        {
            categories.Insert(0, new Category { Id = 0, Name = "Все" });
            Categories = new SelectList(categories, "Id", "Name", category);
            SelectedCategory = category;
            SelectedName = name;
        }
        public SelectList Categories { get; private set; }
        public int? SelectedCategory { get; private set; }
        public string SelectedName { get; private set; }
    }
}
