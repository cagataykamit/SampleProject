using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.StockList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IStockListDal : IEntityRepository<StockList>
    {
        List<StockListDto> GetAllForTable();
    }
}
