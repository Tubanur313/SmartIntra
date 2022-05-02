﻿using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System.Collections.Generic;

namespace SmartIntranet.Entities.Concrete
{
    public class Position: BaseEntity
    {
        //public int Id { get; set; }
        public int? ParentId { get; set; }
        public virtual Position Parent { get; set; }

        public virtual ICollection<Position> Children { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public virtual ICollection<IntranetUser> IntranetUsers { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
