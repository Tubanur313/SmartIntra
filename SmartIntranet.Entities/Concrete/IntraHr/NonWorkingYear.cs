using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;


namespace SmartIntranet.Entities.Concrete
{
    public class NonWorkingYear : BaseEntity
    {
        public virtual ICollection<NonWorkingDay> NonWorkingDays { get; set; }
        public virtual ICollection<WorkGraphic> WorkGraphics { get; set; }
        public string Year { get; set; }
    }
}
