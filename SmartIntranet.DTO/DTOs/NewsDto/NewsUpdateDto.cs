using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.NewsDto
{
    public class NewsUpdateDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public virtual ICollection<NewsFile> NewsFiles { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
        public int? AppUserId { get; set; }
        public IntranetUser AppUser { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
