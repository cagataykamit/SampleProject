using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StockTypeManager : IStockTypeService
    {
        IStockTypeDal _stockTypeDal;
        public StockTypeManager(IStockTypeDal stockTypeDal)
        {
            _stockTypeDal = stockTypeDal;
        }

        public IDataResult<List<StockType>> GetAll()
        {

            return new SuccessDataResult<List<StockType>>(_stockTypeDal.GetAll(), Messages.StockTypeListed);
        }

        [ValidationAspect(typeof(StockTypeValidator))]
        public IResult Add(StockType stockType)
        {
            //business codes


            IResult result = BusinessRules.Run(CheckIfStockTypeNameExist(stockType.Name)
                                          
                                          );

            if (result != null)
            {
                return result;
            }
            _stockTypeDal.Add(stockType);

            return new SuccessResult(Messages.ProductAdded);
        }
        private IResult CheckIfStockTypeNameExist(string stockTypeName)
        {
            var result = _stockTypeDal.GetAll(p => p.Name == stockTypeName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }

        public IResult Update(StockType stockType)
        {
            throw new NotImplementedException();
        }
    }
}
