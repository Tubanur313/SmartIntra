using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DTO.DTOs.CategoryNewsDto
{
    public class CategoryNewsListDto
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
