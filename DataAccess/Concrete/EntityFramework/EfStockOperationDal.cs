﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStockOperationDal : EfEntityRepositoryBase<StockOperation, StockContext>, IStockOperationDal
    {
        public List<StockOperationDto> GetAllForTable()
        {
            using (StockContext context = new StockContext())
            {
                var result = from so in context.StockOperations
                             join s in context.Stocks on so.IdStock equals s.Id
                             join st in context.StockTypes on s.IdStockType equals st.Id
                             join sh in context.Shelfs on so.IdShelf equals sh.Id
                             join c in context.Cabinets on so.IdCabinet equals c.Id
                             where so.Deleted == false && s.Deleted == false && st.Deleted == false && sh.Deleted == false && c.Deleted == false
                             select new StockOperationDto
                             {
                                 Id = so.Id,
                                 StockCode = s.StockCode,
                                 Amount = so.Amount,
                                 ShelfCode = sh.Code,
                                 CabinetCode = c.Code,
                                 CriticalAmount = so.CriticalAmount,
                                 StockTypeName = st.Name
                             };
                return result.ToList();
            }
        }
    }
}
