using Entities.Concrete;
using Entities.DTOs.StockUnit;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Models
{
    public class StockUnitViewModel
    {
        public List<StockUnitWithStockTypeDto>? ListStockUnit { get; set; }
        public StockUnit Model { get; set; }
        public List<SelectListItem> StockTypeItems { get; set; }
        public List<SelectListItem> QuantityUnitItems { get; set; }
        public List<SelectListItem> CurrencyTypePurchaseItems { get; set; }
        public List<SelectListItem> CurrencyTypeSaleItems { get; set; }




    }
}
