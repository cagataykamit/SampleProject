using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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

namespace Business.Concrete
{
    public class StockListManager : IStockListService
    {
        IStockListDal _stockListDal;
        public StockListManager(IStockListDal stockListDal)
        {
            _stockListDal = stockListDal;
        }

        public IDataResult<List<StockListDto>> GetAll()
        {

            return new SuccessDataResult<List<StockListDto>>(_stockListDal.GetAllForTable(), Messages.StockListTypeListed);
        }

        [ValidationAspect(typeof(StockListValidator))]
        public IResult Add(StockList StockList)
        {
            //business codes
            //IResult result = BusinessRules.Run(CheckIfStockListNameExist(StockList.Name));

            //if (result != null)
            //{
            //    return result;
            //}
            _stockListDal.Add(StockList);

            return new SuccessResult(Messages.ProductAdded);
        }
        //private IResult CheckIfStockListNameExist(string StockListName)
        //{
        //    var result = _StockListDal.GetAll(p => p.Name == StockListName).Any();
        //    if (result)
        //    {
        //        return new ErrorResult(Messages.ProductNameAlreadyExist);
        //    }
        //    return new SuccessResult();
        //}

        public IResult Delete(StockList StockList)
        {

            var objStockList = _stockListDal.Get(x => x.Id == StockList.Id);
 
            _stockListDal.Delete(StockList);
            return new SuccessResult(Messages.StockListDeleted);
        }

        public IResult Update(StockList StockList)
        {

            var objStockList = _stockListDal.Get(x=>x.Id == StockList.Id);

            // TODO kamit düzelt

            //objStockList.SalePrice = StockList.SalePrice;
            //objStockList.PurchasePrice = StockList.PurchasePrice;
            //objStockList.IdCurrencyTypePurchase = StockList.IdCurrencyTypePurchase;
            //objStockList.StockListCode = StockList.StockListCode;
            //objStockList.Description = StockList.Description;
            //objStockList.IdAmountType = StockList.IdAmountType;
            //objStockList.IdCurrencyTypePurchase = StockList.IdCurrencyTypePurchase;
            //objStockList.IdCurrencyTypeSale = StockList.IdCurrencyTypeSale;
            //objStockList.IdStockListType = StockList.IdStockListType;
            //objStockList.Weight = StockList.Weight;
            _stockListDal.Update(StockList);
            return new SuccessResult(Messages.StockListUpdated);
        }
    }
}
