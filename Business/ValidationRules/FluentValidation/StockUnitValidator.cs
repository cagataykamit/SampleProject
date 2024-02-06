using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class StockUnitValidator : AbstractValidator<StockUnit>
    {
        public StockUnitValidator()
        {
            RuleFor(s => s.SalePrice).GreaterThan(10);
            RuleFor(s => s.IdStockType).NotEmpty().WithMessage("Lütfen stok türünü giriniz!");
            RuleFor(s => s.IdQuantityUnit).NotEmpty().WithMessage("Lütfen miktar birimini giriniz!");


        }

    }
}
