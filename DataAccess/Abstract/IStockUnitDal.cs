using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.StockUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IStockUnitDal : IEntityRepository<StockUnit>
    {
        List<StockSelectListDto> GetAllStocksByStockType(int idStockType);
        List<StockUnitWithStockTypeDto> GetAllWithStockType();
    }
}
