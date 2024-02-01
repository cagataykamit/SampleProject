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
    public interface IStockTypeService
    {
        IDataResult<List<StockType>> GetAll();
        IResult Add(StockType stockType);
        IResult Update(StockType stockType);
        List<SelectListItem> GetAllStockTypesSelectList();
    }
}
