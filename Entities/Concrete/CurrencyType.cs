using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete;

public partial class CurrencyType : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Deleted { get; set; }

    public virtual ICollection<Stock> StockIdCurrencyTypePurchaseNavigations { get; set; } = new List<Stock>();

    public virtual ICollection<Stock> StockIdCurrencyTypeSaleNavigations { get; set; } = new List<Stock>();
}
