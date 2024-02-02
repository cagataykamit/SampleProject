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

namespace Business.Concrete
{
    public class StockClassManager : IStockClassService
    {
        private readonly IStockClassDal _stockClassDal;

        public StockClassManager(IStockClassDal stockClassDal)
        {
            _stockClassDal = stockClassDal;
        }
        public IResult Add(StockClass stockClass)
        {
            stockClass.Deleted = false;
            _stockClassDal.Add(stockClass);

            return new SuccessResult(Messages.StockClassAdded);
        }

        public IDataResult<List<StockClass>> GetAll()
        {
            return new SuccessDataResult<List<StockClass>>(_stockClassDal.GetAll(), Messages.StockClassListed);
        }

        public List<SelectListItem> GetAllStockClassSelectList()
        {
            return _stockClassDal.GetAllStockClassSelectList();
        }

        public IResult Update(StockClass stockClass)
        {
            var objStockClass = _stockClassDal.Get(x => x.Id == stockClass.Id);

            objStockClass.Name = stockClass.Name;
            objStockClass.Deleted = stockClass.Deleted;

            _stockClassDal.Update(stockClass);
            return new SuccessResult(Messages.StockClassUpdated);
        }
    }
}
