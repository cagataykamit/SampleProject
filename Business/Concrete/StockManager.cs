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
    public class StockManager : IStockService
    {
        IStockDal _StockDal;
        public StockManager(IStockDal StockDal)
        {
            _StockDal = StockDal;
        }

        public IDataResult<List<Stock>> GetAll()
        {

            return new SuccessDataResult<List<Stock>>(_StockDal.GetAll(), Messages.StockTypeListed);
        }

        [ValidationAspect(typeof(StockValidator))]
        public IResult Add(Stock Stock)
        {
            //business codes
            //IResult result = BusinessRules.Run(CheckIfStockNameExist(Stock.Name));

            //if (result != null)
            //{
            //    return result;
            //}
            _StockDal.Add(Stock);

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

        public IResult Delete(Stock Stock)
        {

            var objStock = _StockDal.Get(x => x.Id == Stock.Id);
 
            _StockDal.Delete(Stock);
            return new SuccessResult(Messages.StockDeleted);
        }

        public IResult Update(Stock Stock)
        {

            var objStock = _StockDal.Get(x=>x.Id == Stock.Id);

            objStock.SalePrice = Stock.SalePrice;
            objStock.PurchasePrice = Stock.PurchasePrice;
            objStock.IdCurrencyTypePurchase = Stock.IdCurrencyTypePurchase;
            objStock.StockCode = Stock.StockCode;
            objStock.Description = Stock.Description;
            objStock.IdAmountType = Stock.IdAmountType;
            objStock.IdCurrencyTypePurchase = Stock.IdCurrencyTypePurchase;
            objStock.IdCurrencyTypeSale = Stock.IdCurrencyTypeSale;
            objStock.IdStockType = Stock.IdStockType;
            objStock.Weight = Stock.Weight;
            _StockDal.Update(Stock);
            return new SuccessResult(Messages.StockUpdated);
        }

        public IDataResult<List<StockSelectListDto>> GetAllStocksByStockType(int idStockType)
        {
            return new SuccessDataResult<List<StockSelectListDto>>(_StockDal.GetAllStocksByStockType(idStockType), Messages.StockTypeListed);
        }
    }
}
