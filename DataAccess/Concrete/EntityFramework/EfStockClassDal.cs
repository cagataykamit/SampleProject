using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStockClassDal : EfEntityRepositoryBase<StockClass, StockContext>, IStockClassDal
    {
        public List<SelectListItem> GetAllStockClassSelectList()
        {
            using (StockContext context = new StockContext())
            {
                var result = from s in context.StockClasses
                             select new SelectListItem
                             {
                                 Value = s.Id.ToString(),
                                 Text = s.Name,
                             };
                return result.ToList();
            }
        }
    }
}
