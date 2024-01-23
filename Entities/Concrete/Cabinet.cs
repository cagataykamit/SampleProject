
using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete;

public partial class Cabinet : IEntity
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public int? IdShelf { get; set; }

    public bool Deleted { get; set; }

    public virtual Shelf? IdShelfNavigation { get; set; }

    public virtual ICollection<StockOperation> StockOperations { get; set; } = new List<StockOperation>();

}
