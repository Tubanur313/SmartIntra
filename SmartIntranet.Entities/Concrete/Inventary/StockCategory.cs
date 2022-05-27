using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Entities.Concrete.Inventary
{
    public class StockCategory:BaseEntity
    {
        public string Name { get; set; } 
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
