using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Inventary;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.InventaryDtos.StockDto
{
    public class StockInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string MacAddress { get; set; }
        public bool Status { get; set; }
        public string SKU { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int StockCategoryId { get; set; }
        public StockCategory StockCategory { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int? IntranerUserId { get; set; }
        public IntranetUser IntranetUser { get; set; }
        //public virtual ICollection<StockImage> StockImages { get; set; }
        //public virtual ICollection<StockDiscuss> StockDiscusses { get; set; }
    }
}
