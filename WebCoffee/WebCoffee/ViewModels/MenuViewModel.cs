﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoffee.Models;

namespace WebCoffee.ViewModels
{
    public class MenuViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
