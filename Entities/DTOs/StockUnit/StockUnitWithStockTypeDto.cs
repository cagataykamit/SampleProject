using Core.Entities;

namespace Entities.DTOs.StockUnit
{
    public class StockUnitWithStockTypeDto : IDto
    {
        public int Id { get; set; }

        public int IdStockType { get; set; }
        public int IdStockClass { get; set; }
        public string? StockCode { get; set; }

        public int IdQuantityUnit { get; set; }

        public string? Description { get; set; }

        public decimal? PurchasePrice { get; set; }

        public int? IdCurrencyTypePurchase { get; set; }

        public decimal? SalePrice { get; set; }

        public int? IdCurrencyTypeSale { get; set; }

        public decimal? Weight { get; set; }

        public bool Deleted { get; set; }

        public string StockTypeName { get; set; }
        public string QuantityUnitName { get; set; }

        public string CurrencyTypeSaleName { get; set; }

        public string CurrencyTypeSaleSymbol { get; set; }

        public string CurrencyTypePurchaseName { get; set; }

        public string CurrencyTypePurchaseSymbol { get; set; }

    }
}
