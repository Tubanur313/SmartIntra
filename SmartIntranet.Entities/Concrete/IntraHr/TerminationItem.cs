using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;


namespace SmartIntranet.Entities.Concrete
{
    public class TerminationItem : BaseEntity
    {
       public string Name { get; set; }
       public string Description { get; set; }
    }
}
