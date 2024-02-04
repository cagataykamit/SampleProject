using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.StockUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Business.Abstract
{
    public interface IStockUnitService
    {
        IDataResult<List<StockUnit>> GetAll();
        IResult Add(StockUnit stockUnit);
        IResult Update(StockUnit stockUnit);
        IResult Delete(StockUnit stockUnit);
        IDataResult<List<StockSelectListDto>> GetAllStockUnitByStockType(int idStockType);
        IDataResult<List<StockUnitWithStockTypeDto>> GetAllWithStockType();

        List<SelectListItem> GetAllStockUnitSelectList();



    }
}
