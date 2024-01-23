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
    public class StockOperationManager : IStockOperationService
    {
        IStockOperationDal _stockOperationDal;
        public StockOperationManager(IStockOperationDal stockOperationDal)
        {
            _stockOperationDal = stockOperationDal;
        }

        public IDataResult<List<StockOperationDto>> GetAll()
        {

            return new SuccessDataResult<List<StockOperationDto>>(_stockOperationDal.GetAllForTable(), Messages.StockOperationTypeListed);
        }

        [ValidationAspect(typeof(StockOperationValidator))]
        public IResult Add(StockOperation StockOperation)
        {
            //business codes
            //IResult result = BusinessRules.Run(CheckIfStockOperationNameExist(StockOperation.Name));

            //if (result != null)
            //{
            //    return result;
            //}
            _stockOperationDal.Add(StockOperation);

            return new SuccessResult(Messages.ProductAdded);
        }
        //private IResult CheckIfStockOperationNameExist(string StockOperationName)
        //{
        //    var result = _StockOperationDal.GetAll(p => p.Name == StockOperationName).Any();
        //    if (result)
        //    {
        //        return new ErrorResult(Messages.ProductNameAlreadyExist);
        //    }
        //    return new SuccessResult();
        //}

        public IResult Delete(StockOperation StockOperation)
        {

            var objStockOperation = _stockOperationDal.Get(x => x.Id == StockOperation.Id);
 
            _stockOperationDal.Delete(StockOperation);
            return new SuccessResult(Messages.StockOperationDeleted);
        }

        public IResult Update(StockOperation StockOperation)
        {

            var objStockOperation = _stockOperationDal.Get(x=>x.Id == StockOperation.Id);

            // TODO kamit düzelt

            //objStockOperation.SalePrice = StockOperation.SalePrice;
            //objStockOperation.PurchasePrice = StockOperation.PurchasePrice;
            //objStockOperation.IdCurrencyTypePurchase = StockOperation.IdCurrencyTypePurchase;
            //objStockOperation.StockOperationCode = StockOperation.StockOperationCode;
            //objStockOperation.Description = StockOperation.Description;
            //objStockOperation.IdAmountType = StockOperation.IdAmountType;
            //objStockOperation.IdCurrencyTypePurchase = StockOperation.IdCurrencyTypePurchase;
            //objStockOperation.IdCurrencyTypeSale = StockOperation.IdCurrencyTypeSale;
            //objStockOperation.IdStockOperationType = StockOperation.IdStockOperationType;
            //objStockOperation.Weight = StockOperation.Weight;
            _stockOperationDal.Update(StockOperation);
            return new SuccessResult(Messages.StockOperationUpdated);
        }
    }
}
