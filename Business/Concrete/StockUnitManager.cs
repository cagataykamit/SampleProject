using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StockUnitManager : IStockUnitService
    {
        IStockUnitDal _stockUnitDal;
        public StockUnitManager(IStockUnitDal stockUnitDal)
        {
            _stockUnitDal = stockUnitDal;
        }

        public IDataResult<List<StockUnit>> GetAll()
        {

            return new SuccessDataResult<List<StockUnit>>(_stockUnitDal.GetAll(), Messages.StockTypeListed);
        }

        [ValidationAspect(typeof(StockUnitValidator))]
        public IResult Add(StockUnit stockUnit)
        {
            //business codes
            //IResult result = BusinessRules.Run(CheckIfStockNameExist(Stock.Name));

            //if (result != null)
            //{
            //    return result;
            //}
            _stockUnitDal.Add(stockUnit);

            return new SuccessResult(Messages.ProductAdded);
        }
        //private IResult CheckIfStockNameExist(string StockName)
        //{
        //    var result = _StockDal.GetAll(p => p.Name == StockName).Any();
        //    if (result)
        //    {
        //        return new ErrorResult(Messages.ProductNameAlreadyExist);
        //    }
        //    return new SuccessResult();
        //}

        public IResult Delete(StockUnit stockUnit)
        {

            var objStock = _stockUnitDal.Get(x => x.Id == stockUnit.Id);

            _stockUnitDal.Delete(stockUnit);
            return new SuccessResult(Messages.StockDeleted);
        }

        public IResult Update(StockUnit stockUnit)
        {

            var objStock = _stockUnitDal.Get(x=>x.Id == stockUnit.Id);

            objStock.SalePrice = stockUnit.SalePrice;
            objStock.PurchasePrice = stockUnit.PurchasePrice;
            objStock.IdCurrencyTypePurchase = stockUnit.IdCurrencyTypePurchase;
            objStock.StockCode = stockUnit.StockCode;
            objStock.Description = stockUnit.Description;
            objStock.IdCurrencyTypePurchase = stockUnit.IdCurrencyTypePurchase;
            objStock.IdCurrencyTypeSale = stockUnit.IdCurrencyTypeSale;
            objStock.IdStockType = stockUnit.IdStockType;
            objStock.Weight = stockUnit.Weight;
            _stockUnitDal.Update(stockUnit);
            return new SuccessResult(Messages.StockUpdated);
        }

        public IDataResult<List<StockSelectListDto>> GetAllStocksByStockType(int idStockType)
        {
            return new SuccessDataResult<List<StockSelectListDto>>(_stockUnitDal.GetAllStocksByStockType(idStockType), Messages.StockTypeListed);
        }
    }
}
