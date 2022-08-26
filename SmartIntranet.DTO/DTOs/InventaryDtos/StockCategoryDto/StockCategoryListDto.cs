using SmartIntranet.Entities.Concrete.Inventary;

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
