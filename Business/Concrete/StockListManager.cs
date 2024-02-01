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
        public IResult Add(StockList stockList)
        {
            //business codes
            //IResult result = BusinessRules.Run(CheckIfStockListNameExist(StockList.Name));

            //if (result != null)
            //{
            //    return result;
            //}
            _stockListDal.Add(stockList);

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

        public IResult Delete(StockList stockList)
        {

            var objStockList = _stockListDal.Get(x => x.Id == stockList.Id);
 
            _stockListDal.Delete(stockList);
            return new SuccessResult(Messages.StockListDeleted);
        }

        public IResult Update(StockList stockList)
        {

            var objStockList = _stockListDal.Get(x=>x.Id == stockList.Id);

            objStockList.IdStockUnit = stockList.IdStockUnit;
            objStockList.Amount = stockList.Amount;
            objStockList.IdShelf = stockList.IdShelf;
            objStockList.IdCabinet = stockList.IdCabinet;
            objStockList.CriticalAmount = stockList.CriticalAmount;
            objStockList.Deleted = stockList.Deleted;
   
            _stockListDal.Update(stockList);
            return new SuccessResult(Messages.StockListUpdated);
        }
    }
}
