using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.Entities.Concrete.Intranet.Archives
{
    public class Archive:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string File { get; set; }

        public int AddedByUserId { get; set; }
        public IntranetUser AddedByUser { get; set; } 
        public int CompanyId { get; set; }
        public Company Company { get; set; } 
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
