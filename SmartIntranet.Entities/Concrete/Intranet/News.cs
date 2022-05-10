using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System.Collections.Generic;

namespace SmartIntranet.Entities.Concrete.Intranet
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? AppUserId { get; set; }
        public IntranetUser AppUser { get; set; }

        public virtual ICollection<NewsFile> NewsFiles { get; set; }
        public virtual ICollection<CategoryNews> CategoryNews { get; set; }
    }
}
