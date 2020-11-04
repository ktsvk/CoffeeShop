using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoffee.ViewModels
{
    public class SortViewModel
    {
        public SortState NameSort { get; private set; }
        public SortState PriceSort { get; private set; }
        public SortState PurchasesSort { get; private set; }
        public SortState CategorySort { get; private set; }
        public SortState Current { get; private set; } 

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            PriceSort = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            PurchasesSort = sortOrder == SortState.PurchasesAsc ? SortState.PurchasesDesc : SortState.PurchasesAsc;
            CategorySort = sortOrder == SortState.CategoryAsc ? SortState.CategoryDesc : SortState.CategoryAsc;
            Current = sortOrder;
        }
    }
}
