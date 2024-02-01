using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.StockList
{
    public class StockListWithStockTypeAndStockUnitDto : IDto
    {
        public int Id { get; set; }

        public int IdStockUnit { get; set; }
        public int StockCode { get; set; }
        public string StockTypeName { get; set; }
        public string StockUnitDescription { get; set; }

        public int Amount { get; set; }

        public int IdShelf { get; set; }

        public int IdCabinet { get; set; }

        public int CriticalAmount { get; set; }

        public bool Deleted { get; set; }

    }
}
