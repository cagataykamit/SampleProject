using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.StockUnit;
using System.Web.Mvc;

namespace Business.Concrete
{
    public class StockUnitManager : IStockUnitService
    {
        IStockUnitDal _stockUnitDal;
        IStockListDal _stockListDal;
        public StockUnitManager(IStockUnitDal stockUnitDal, IStockListDal stockListDal)
        {
            _stockUnitDal = stockUnitDal;
            _stockListDal = stockListDal;
        }

        public IDataResult<List<StockUnit>> GetAll()
        {

            return new SuccessDataResult<List<StockUnit>>(_stockUnitDal.GetAll(), Messages.StockTypeListed);
        }

        [ValidationAspect(typeof(StockUnitValidator))]
        public IResult Add(StockUnit stockUnit)
        {
            _stockUnitDal.Add(stockUnit);

            return new SuccessResult(Messages.StockTypeAdded);
        }

        [LogAspect(typeof(FileLogger))]
        public IResult Delete(StockUnit stockUnit)
        {

            var objStock = _stockUnitDal.Get(x => x.Id == stockUnit.Id);
            IResult result = BusinessRules.Run(CheckIsThereAStockUnitIdInTheStockList(stockUnit.Id));
            
            if (result != null)
            {
                return result;
            }
            _stockUnitDal.Delete(stockUnit);
            return new SuccessResult(Messages.StockUnitDeleted);
        }

        [ValidationAspect(typeof(StockUnitValidator))]
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
            return new SuccessResult(Messages.StockUnitUpdated);
        }

        public IDataResult<List<StockSelectListDto>> GetAllStockUnitByStockType(int idStockType)
        {
            return new SuccessDataResult<List<StockSelectListDto>>(_stockUnitDal.GetAllStockUnitByStockType(idStockType), Messages.StockTypeListed);
        }

        public IDataResult<List<StockUnitWithStockTypeDto>> GetAllWithStockType()
        {
            return new SuccessDataResult<List<StockUnitWithStockTypeDto>>(_stockUnitDal.GetAllWithStockType(), Messages.StockTypeListed);
        }

        public List<SelectListItem> GetAllStockUnitSelectList()
        {
            return _stockUnitDal.GetAllStockUnitSelectList();
        }
        //Stok Birimi bir Stok Listesinde kullanılmış ise silme işlemini engelle
        private IResult CheckIsThereAStockUnitIdInTheStockList(int Id)
        {
            var objStockList = _stockListDal.GetAll(x => x.IdStockUnit == Id);
            if (objStockList.Any())
            {
                return new ErrorResult(Messages.StockUnitInStockListNotDelete);
            }
            return new SuccessResult();
        }
    }
}
