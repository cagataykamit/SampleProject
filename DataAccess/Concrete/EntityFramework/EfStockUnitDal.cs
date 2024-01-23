using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStockUnitDal : EfEntityRepositoryBase<StockUnit, StockContext>, IStockUnitDal
    {
        public List<StockSelectListDto> GetAllStocksByStockType(int idStockType)
        {
            using (StockContext context = new StockContext())
            {
                var result = from s in context.StockUnits
                             where s.IdStockType == idStockType && s.Deleted == false
                             select new StockSelectListDto
                             {
                                 Id = s.Id,
                                 StockCode = s.StockCode,

                             };
                return result.ToList();
            }
        }
    }
}
