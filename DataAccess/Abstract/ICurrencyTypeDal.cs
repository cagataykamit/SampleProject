using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccess.Abstract
{
    public interface ICurrencyTypeDal : IEntityRepository<CurrencyType>
    {
        List<SelectListItem> GetAllCurrencyTypeSelectList();
    }
}
