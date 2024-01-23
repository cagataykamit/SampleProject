using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete;

public partial class StockList : IEntity
{
    public int Id { get; set; }

    public int IdStockUnit { get; set; }

    public int Amount { get; set; }

    public int IdShelf { get; set; }

    public int IdCabinet { get; set; }

    public int CriticalAmount { get; set; }

    public bool Deleted { get; set; }

    public virtual Cabinet IdCabinetNavigation { get; set; } = null!;

    public virtual Shelf IdShelfNavigation { get; set; } = null!;

    public virtual StockUnit IdStockUnitNavigation { get; set; } = null!;

}
