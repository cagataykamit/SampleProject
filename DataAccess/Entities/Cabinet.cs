using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Cabinet
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public int? IdShelf { get; set; }

    public bool Deleted { get; set; }

    public virtual Shelf? IdShelfNavigation { get; set; }

    public virtual ICollection<StockList> StockLists { get; set; } = new List<StockList>();
}
