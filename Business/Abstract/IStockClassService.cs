using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Business.Abstract
{
    public interface IStockClassService
    {
        IDataResult<List<StockClass>> GetAll();
        IResult Add(StockClass stockClass);
        IResult Update(StockClass stockClass);
        List<SelectListItem> GetAllStockClassSelectList();
    }
}
