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
    public interface IStockOperationService
    {
        IDataResult<List<StockOperationDto>> GetAll();
        IResult Add(StockOperation stockOperation);
        IResult Update(StockOperation stockOperation);
    }
}
