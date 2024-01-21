using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete;

public partial class Shelf : IEntity
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public bool? Deleted { get; set; }

    public virtual ICollection<Cabinet> Cabinets { get; set; } = new List<Cabinet>();
}
