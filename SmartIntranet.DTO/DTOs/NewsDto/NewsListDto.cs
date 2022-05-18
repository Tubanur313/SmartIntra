using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;

namespace SmartIntranet.DTO.DTOs.NewsDto
{
    public class NewsListDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<NewsFile> NewsFiles { get; set; }
        public virtual ICollection<CategoryNews> CategoryNews { get; set; }
        public int? AppUserId { get; set; }
        public IntranetUser AppUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
