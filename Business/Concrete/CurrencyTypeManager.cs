using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Razor.Parser.SyntaxTree;

namespace Business.Concrete
{
    public class CurrencyTypeManager : ICurrencyTypeService
    {
        private readonly ICurrencyTypeDal _currencyTypeDal;

        public CurrencyTypeManager(ICurrencyTypeDal currencyTypeDal)
        {
            _currencyTypeDal = currencyTypeDal;
        }
        public IResult Add(CurrencyType currencyType)
        {
            currencyType.Deleted = false;
            _currencyTypeDal.Add(currencyType);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<CurrencyType>> GetAll()
        {
            return new SuccessDataResult<List<CurrencyType>>(_currencyTypeDal.GetAll(), Messages.CurrencyTypeListed);
        }

        public List<SelectListItem> GetAllCurrencyTypeSelectList()
        {
            return _currencyTypeDal.GetAllCurrencyTypeSelectList();
        }

        public IResult Update(CurrencyType currencyType)
        {
            var objCurrencyType = _currencyTypeDal.Get(x => x.Id == currencyType.Id);

            objCurrencyType.Name = currencyType.Name;
            objCurrencyType.Symbol = currencyType.Symbol;
            objCurrencyType.Deleted = currencyType.Deleted;

            _currencyTypeDal.Update(currencyType);
            return new SuccessResult(Messages.StockTypeUpdated);
        }
    }
}
