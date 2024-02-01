using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.StockUnit;
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

        public List<StockUnitWithStockTypeDto> GetAllWithStockType()
        {
            using (StockContext context = new StockContext())
            {
                var result = from s in context.StockUnits

                             join st in context.StockTypes on s.IdStockType equals st.Id

                             join qt in context.QuantityUnits on s.IdQuantityUnit equals qt.Id
                 
                             join cts in context.CurrencyTypes on s.IdCurrencyTypeSale equals cts.Id into ctsGroup
                             from cts in ctsGroup.DefaultIfEmpty()

                             join ctp in context.CurrencyTypes on s.IdCurrencyTypePurchase equals ctp.Id into ctpGroup
                             from ctp in ctpGroup.DefaultIfEmpty()

                             select new StockUnitWithStockTypeDto
                             {
                                 Id = s.Id,
                                 StockCode = s.StockCode,                             
                                 Description = s.Description,
                                 PurchasePrice = s.PurchasePrice,
                                 SalePrice = s.SalePrice,
                                 Weight = s.Weight,
                                 IdQuantityUnit = qt.Id,
                                 QuantityUnitName = qt.Name,
                                 StockTypeName = st.Name,
                                 CurrencyTypePurchaseName = ctp.Name,
                                 CurrencyTypePurchaseSymbol = ctp.Symbol,
                                 CurrencyTypeSaleSymbol = cts.Symbol,
                                 CurrencyTypeSaleName = cts.Name,                               
                             };
                return result.ToList();
            }
        }
    }
}
