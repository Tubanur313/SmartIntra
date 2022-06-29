using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Inventary;
using SmartIntranet.Entities.Concrete.Membership;
using System;

namespace SmartIntranet.DTO.DTOs.InventaryDtos.StockDto
{
    public class StockUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DepreciationPercent { get; set; }
        public DateTime BuyDate { get; set; }
        public string Price { get; set; }
        public string MacAddress { get; set; }
        public string SKU { get; set; }
        public int StockCategoryId { get; set; }
        public StockCategory StockCategory { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int? IntranerUserId { get; set; }
        public IntranetUser IntranetUser { get; set; }
    }
}
