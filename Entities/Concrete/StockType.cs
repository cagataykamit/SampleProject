using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete;

public partial class StockType : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool Deleted { get; set; }

    public virtual ICollection<StockList> StockLists { get; set; } = new List<StockList>();

    public virtual ICollection<StockUnit> StockUnits { get; set; } = new List<StockUnit>();
}
