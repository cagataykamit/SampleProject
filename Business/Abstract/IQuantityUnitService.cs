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
    public interface IQuantityUnitService
    {
        IDataResult<List<QuantityUnit>> GetAll();
        IResult Add(QuantityUnit quantityUnit);
        IResult Update(QuantityUnit quantityUnit);
        List<SelectListItem> GetAllQuantityUnitSelectList();
    }
}
