using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.StockList;

namespace Business.Concrete
{
    public class StockListManager : IStockListService
    {
        IStockListDal _stockListDal;
        public StockListManager(IStockListDal stockListDal)
        {
            _stockListDal = stockListDal;
        }

        public IDataResult<List<StockListWithStockTypeAndStockUnitDto>> GetAll()
        {

            return new SuccessDataResult<List<StockListWithStockTypeAndStockUnitDto>>(_stockListDal.GetAllForTable(), Messages.StockListListed);
        }

        [ValidationAspect(typeof(StockListValidator))]
        public IResult Add(StockList stockList)
        {
            _stockListDal.Add(stockList);

            return new SuccessResult(Messages.StockListAdded);
        }

        public IResult Delete(StockList stockList)
        {

            var objStockList = _stockListDal.Get(x => x.Id == stockList.Id);

            _stockListDal.Delete(stockList);
            return new SuccessResult(Messages.StockListDeleted);
        }
        [ValidationAspect(typeof(StockListValidator))]
        public IResult Update(StockList stockList)
        {
            var objStockList = _stockListDal.Get(x => x.Id == stockList.Id);

            objStockList.IdStockUnit = stockList.IdStockUnit;
            objStockList.Amount = stockList.Amount;
            objStockList.IdShelf = stockList.IdShelf;
            objStockList.IdCabinet = stockList.IdCabinet;
            objStockList.CriticalAmount = stockList.CriticalAmount;
            objStockList.IdStockClass = stockList.IdStockClass;
            objStockList.IdStockType = stockList.IdStockType;
            objStockList.Deleted = stockList.Deleted;

            _stockListDal.Update(objStockList); // Burada objStockList'i güncellemelisiniz, stockList değil.
            return new SuccessResult(Messages.StockListUpdated);
        }

        public IDataResult<List<StockListWithStockTypeAndStockUnitDto>> GetAllForTable()
        {
            return new SuccessDataResult<List<StockListWithStockTypeAndStockUnitDto>>(_stockListDal.GetAllForTable(), Messages.StockTypeListed);
        }

        IDataResult<List<StockListDto>> IStockListService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
