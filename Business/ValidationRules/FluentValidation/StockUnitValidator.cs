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
            //RuleFor(p => p.SalePrice).Min(2);
            //RuleFor(p => p.Name).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalıdır.");
        }

    }
}
