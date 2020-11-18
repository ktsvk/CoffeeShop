using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoffee.ViewModels
{
    public class PageViewModel
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int VisiblePagesRange { get; set; }
        public int Amount { get; set; }

        public PageViewModel(int count, int current, int pageSize, int visiblePagesRange, int amount)
        {
            CurrentPage = current;
            Amount = amount;
            VisiblePagesRange = visiblePagesRange;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }
    }
}
