using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Intranet.Archives;

namespace SmartIntranet.Entities.Concrete
{
    public class Department : BaseEntity
    {
        public int? ParentId { get; set; }
        public virtual Department Parent { get; set; }

        public virtual ICollection<Department> Children { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<IntranetUser> IntranetUsers { get; set; }
        public virtual ICollection<Archive> Archives { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
