using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class StockTypeValidator : AbstractValidator<StockType>
    {
        public StockTypeValidator()
        {
            RuleFor(p => p.Name).MinimumLength(2);          
        }

    }
}
