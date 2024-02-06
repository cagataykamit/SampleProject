using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class StockListValidator : AbstractValidator<StockList>
    {
        public StockListValidator()
        {
            RuleFor(s => s.IdStockClass).NotEmpty().WithMessage("Lütfen stok sınıfını giriniz!");
            RuleFor(s => s.IdStockType).NotEmpty().WithMessage("Lütfen stok türünü giriniz!");
            RuleFor(s => s.IdStockUnit).NotEmpty().WithMessage("Lütfen stok birimini giriniz!");
            RuleFor(s => s.Amount).NotEmpty().WithMessage("Lütfen miktarı giriniz!");
            RuleFor(s => s.IdShelf).NotEmpty().WithMessage("Lütfen raf bilgisini giriniz!");
            RuleFor(s => s.IdCabinet).NotEmpty().WithMessage("Lütfen dolap bilgisini giriniz!");
            RuleFor(s => s.CriticalAmount).NotEmpty().WithMessage("Lütfen kiritik miktarı giriniz!");

        }

    }
}
