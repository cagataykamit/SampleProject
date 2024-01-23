using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class CurrencyType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Deleted { get; set; }

    public virtual ICollection<StockUnit> StockUnitIdCurrencyTypePurchaseNavigations { get; set; } = new List<StockUnit>();

    public virtual ICollection<StockUnit> StockUnitIdCurrencyTypeSaleNavigations { get; set; } = new List<StockUnit>();
}
