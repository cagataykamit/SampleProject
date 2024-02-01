using Entities.Concrete;
using Entities.DTOs.StockList;
using Entities.DTOs.StockUnit;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Models
{
    public class StockListViewModel
    {
        public List<StockListWithStockTypeAndStockUnitDto>? ListStockList { get; set; }
        public StockList Model { get; set; }
    }
}
