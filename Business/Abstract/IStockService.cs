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
    public interface IStockService
    {
        IDataResult<List<Stock>> GetAll();
        IResult Add(Stock stock);
        IResult Update(Stock stock);
        IDataResult<List<StockSelectListDto>> GetAllStocksByStockType(int idStockType);
    }
}
