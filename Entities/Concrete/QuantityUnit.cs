using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class QuantityUnit:IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool Deleted { get; set; }

        public virtual ICollection<StockUnit> StockUnits { get; set; } = new List<StockUnit>();
    }
}
