using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Entities.Concrete
{
    public class Order:BaseEntity
    {
        public string Product { get; set; }
        public string Currency { get; set; }
        public string Quantity { get; set; }
        public string WithoutVat { get; set; }
        public string TotalWithoutTax { get; set; }
        public string TaxType { get; set; }
        public string Total { get; set; }
        public string Seller { get; set; } 
        public string Description { get; set; }
        public virtual ICollection<TicketOrder> TicketOrders { get; set; }
    }
}
