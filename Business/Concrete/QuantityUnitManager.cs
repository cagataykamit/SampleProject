using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.StockList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Razor.Parser.SyntaxTree;

namespace Business.Concrete
{
    public class QuantityUnitManager : IQuantityUnitService
    {
        private readonly IQuantityUnitDal _quantityUnitDal;

        public QuantityUnitManager(IQuantityUnitDal quantityUnitDal)
        {
            _quantityUnitDal = quantityUnitDal;
        }
        public IResult Add(QuantityUnit quantityUnit)
        {
            quantityUnit.Deleted = false;
            _quantityUnitDal.Add(quantityUnit);

            return new SuccessResult(Messages.QuantityUnitAdded);
        }

        public IDataResult<List<QuantityUnit>> GetAll()
        {
            return new SuccessDataResult<List<QuantityUnit>>(_quantityUnitDal.GetAll(), Messages.QuantityUnitListed);
        }

        public IResult Update(QuantityUnit quantityUnit)
        {
            var objQuantityUnit = _quantityUnitDal.Get(x => x.Id == quantityUnit.Id);

            objQuantityUnit.Name = quantityUnit.Name;
            objQuantityUnit.Deleted = quantityUnit.Deleted;

            _quantityUnitDal.Update(quantityUnit);
            return new SuccessResult(Messages.QuantityUnitUpdated);
        }

        public List<SelectListItem> GetAllQuantityUnitSelectList()
        {
            return _quantityUnitDal.GetAllQuantityUnitSelectList();
        }
    }
}
