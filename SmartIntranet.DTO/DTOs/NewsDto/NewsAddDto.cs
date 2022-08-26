using SmartIntranet.Entities.Concrete.Intranet;
using System.Collections.Generic;

namespace SmartIntranet.DTO.DTOs.NewsDto
{
    public class NewsAddDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<NewsFile> NewsFiles { get; set; }
        public List<int> CategoriesId { get; set; }
        public int AppUserId { get; set; }
    }
}
