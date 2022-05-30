using SmartIntranet.Entities.Concrete.Inventary;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.InventaryDtos.StockCategoryDto
{
    public class StockCategoryListDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public StockCategory Parent { get; set; }
        public string Name { get; set; }
    }
}
