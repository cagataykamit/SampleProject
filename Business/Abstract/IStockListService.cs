using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.StockList;
using Entities.DTOs.StockUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStockListService
    {
        IDataResult<List<StockListDto>> GetAll();
        IResult Add(StockList stockList);
        IResult Update(StockList StockList);
        IDataResult<List<StockListWithStockTypeAndStockUnitDto>> GetAllForTable();
    }
}
