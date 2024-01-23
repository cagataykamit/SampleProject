using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class StockType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool Deleted { get; set; }

    public virtual ICollection<StockUnit> StockUnits { get; set; } = new List<StockUnit>();
}
