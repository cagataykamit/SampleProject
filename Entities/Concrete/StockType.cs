using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete;

public  class StockType :IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool? Deleted { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
