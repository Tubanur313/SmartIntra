using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;

namespace SmartIntranet.Entities.Concrete.Inventary
{
    public class Stock : BaseEntity
    {
        public string Name { get; set; }
        public decimal DepreciationPercent { get; set; }
        public DateTime BuyDate { get; set; }
        public decimal Price { get; set; }
        public string MacAddress { get; set; }
        public string SKU { get; set; }
        public int StockCategoryId { get; set; }
        public StockCategory StockCategory { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int? IntranerUserId { get; set; }
        public IntranetUser IntranetUser { get; set; }
        public virtual ICollection<StockImage> StockImages { get; set; }
        public virtual ICollection<StockDiscuss> StockDiscusses { get; set; }
    }
}
