using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class StockClass : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool Deleted { get; set; }

        public virtual ICollection<StockList> StockLists { get; set; } = new List<StockList>();
    }
}
