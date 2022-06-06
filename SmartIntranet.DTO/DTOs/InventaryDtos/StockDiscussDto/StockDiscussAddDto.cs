using Microsoft.AspNetCore.Http;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System.Collections.Generic;

namespace SmartIntranet.DTO.DTOs.InventaryDtos.StockDiscussDto
{
    public class StockDiscussAddDto
    {
        public string Content { get; set; }
        public int? StockId { get; set; }

    }
}
