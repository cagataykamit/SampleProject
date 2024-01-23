using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Shelf
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public bool Deleted { get; set; }

    public virtual ICollection<Cabinet> Cabinets { get; set; } = new List<Cabinet>();

    public virtual ICollection<StockList> StockLists { get; set; } = new List<StockList>();
}
