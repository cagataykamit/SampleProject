using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Models
{
    public class StockTypeViewModel
    {
        public List<StockType>? LstStock {  get; set; }

        public StockType Model { get; set; }  // Model'i başlatın

        public List<SelectListItem> ListUnit { get; set; }
    }

}
