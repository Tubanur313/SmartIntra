using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using System.Collections.Generic;

namespace SmartIntranet.DTO.DTOs.NewsDto
{
    public class NewsUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AppUserId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<NewsFile> NewsFiles { get; set; }
        public virtual ICollection<CategoryNews> CategoryNews { get; set; }
        public List<int> CategoriesId { get; set; }
    }
}
