using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System.Collections.Generic;


namespace SmartIntranet.Entities.Concrete
{
    public class Department : BaseEntity
    {
        public int? ParentId { get; set; }
        public virtual Department Parent { get; set; }

        public virtual ICollection<Department> Children { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<IntranetUser> IntranetUsers { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
