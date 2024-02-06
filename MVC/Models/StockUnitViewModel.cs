using Entities.Concrete;
using Entities.DTOs.StockUnit;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Models
{
    public class StockUnitViewModel
    {
        public List<StockUnitWithStockTypeDto>? ListStockUnit { get; set; }
        public int Id { get; set; }

        public string? StockCode { get; set; }

        public int IdStockType { get; set; }

        public int IdQuantityUnit { get; set; }

        public string? Description { get; set; }

        public decimal? PurchasePrice { get; set; }

        public int? IdCurrencyTypePurchase { get; set; }

        public decimal? SalePrice { get; set; }

        public int? IdCurrencyTypeSale { get; set; }

        public decimal? Weight { get; set; }
        public int IdShelf { get; set; }
        public int IdCabinet { get; set; }

        public List<SelectListItem> StockTypeItems { get; set; }
        public List<SelectListItem> QuantityUnitItems { get; set; }
        public List<SelectListItem> CurrencyTypePurchaseItems { get; set; }
        public List<SelectListItem> CurrencyTypeSaleItems { get; set; }




    }
}
