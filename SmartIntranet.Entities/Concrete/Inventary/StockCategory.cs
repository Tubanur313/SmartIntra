using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace SmartIntranet.Entities.Concrete.Inventary
{
    public class StockCategory:BaseEntity
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual StockCategory Parent { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
