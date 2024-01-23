
using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete;

public partial class CurrencyType : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Symbol { get; set; }

    public bool Deleted { get; set; }

    public virtual ICollection<StockUnit> StockUnitIdCurrencyTypePurchaseNavigations { get; set; } = new List<StockUnit>();

    public virtual ICollection<StockUnit> StockUnitIdCurrencyTypeSaleNavigations { get; set; } = new List<StockUnit>();
}
