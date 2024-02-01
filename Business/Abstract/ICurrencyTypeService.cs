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
    public interface ICurrencyTypeService
    {
        IDataResult<List<CurrencyType>> GetAll();
        IResult Add(CurrencyType currencyType);
        IResult Update(CurrencyType currencyType);
        List<SelectListItem> GetAllCurrencyTypeSelectList();
    }
}
