using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.StockUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccess.Abstract
{
    public interface IStockUnitDal : IEntityRepository<StockUnit>
    {
        List<StockSelectListDto> GetAllStockUnitByStockType(int idStockType);
        List<StockUnitWithStockTypeDto> GetAllWithStockType();
        List<SelectListItem> GetAllStockUnitSelectList();
    }
}
