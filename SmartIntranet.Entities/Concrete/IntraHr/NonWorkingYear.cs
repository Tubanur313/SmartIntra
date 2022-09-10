using System.Collections.Generic;
using SmartIntranet.Core.Entities.Concrete;

namespace SmartIntranet.Entities.Concrete.IntraHr
{
    public class NonWorkingYear : BaseEntity
    {
        public virtual ICollection<NonWorkingDay> NonWorkingDays { get; set; }
        public virtual ICollection<WorkGraphic> WorkGraphics { get; set; }
        public string Year { get; set; }
    }
}
