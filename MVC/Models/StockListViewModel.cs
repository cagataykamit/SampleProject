using Entities.Concrete;
using Entities.DTOs.StockList;
using Entities.DTOs.StockUnit;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Models
{
    public class StockListViewModel
    {
        public List<StockListWithStockTypeAndStockUnitDto>? ListStockList { get; set; }
        public int Id { get; set; }

        public int IdStockClass { get; set; }

        public int IdStockUnit { get; set; }

        public int IdStockType { get; set; }

        public int Amount { get; set; }

        public int IdShelf { get; set; }
        public int ShelfCode { get; set; }

        public int IdCabinet { get; set; }
        public int CabinetCode { get; set; }
        public int CriticalAmount { get; set; }

        public bool Deleted { get; set; }

        public virtual Cabinet IdCabinetNavigation { get; set; } = null!;

        public virtual Shelf IdShelfNavigation { get; set; } = null!;

        public virtual StockClass IdStockClassNavigation { get; set; } = null!;

        public virtual StockType IdStockTypeNavigation { get; set; } = null!;

        public virtual StockUnit IdStockUnitNavigation { get; set; } = null!;

        public List<SelectListItem> StockTypeItems { get; set; }
        public List<SelectListItem> StockUnitItems { get; set; }
        public List<SelectListItem> StockClassItems { get; set; }
    }
}
