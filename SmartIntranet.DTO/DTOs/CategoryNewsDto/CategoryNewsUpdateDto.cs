using SmartIntranet.Entities.Concrete.Intranet;
using System.Collections.Generic;

namespace SmartIntranet.DTO.DTOs.CategoryNewsDto
{
    public class CategoryNewsUpdateDto
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public List<int> CategoriesId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
