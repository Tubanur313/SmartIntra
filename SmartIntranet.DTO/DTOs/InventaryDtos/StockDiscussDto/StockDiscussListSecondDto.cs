using SmartIntranet.Entities.Concrete.Membership;
using System;


namespace SmartIntranet.DTO.DTOs.InventaryDtos.StockDiscussDto
{
    public class StockDiscussListSecondDto
    {
        public string Content { get; set; }
        public int? IntranetUserId { get; set; }
        public IntranetUser IntranetUser { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
