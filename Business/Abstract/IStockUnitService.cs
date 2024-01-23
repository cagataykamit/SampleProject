using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStockUnitService
    {
        IDataResult<List<StockUnit>> GetAll();
        IResult Add(StockUnit stockUnit);
        IResult Update(StockUnit stockUnit);
        IDataResult<List<StockSelectListDto>> GetAllStocksByStockType(int idStockType);
    }
}
