using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.Entities.Concrete.Inventary;
using System;

namespace SmartIntranet.DTO.DTOs.InventaryDtos.StockDiscussDto
{
    public class StockDiscussListDto
    {
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? IntranetUserId { get; set; }
        public AppUserDetailsDto IntranetUser { get; set; }
        public int? StockId { get; set; }
        public Stock Stock { get; set; }
    }
}
