using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartIntranet.Entities.Concrete
{
    public class Cause : BaseEntity
    {
        public string Name { get; set; }
        //public virtual ICollection<Contract> Contracts { get; set; }
    }
}
