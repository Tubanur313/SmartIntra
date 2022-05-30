using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.Entities.Concrete
{
    public class ReportEmployee : BaseEntity
    {
        public string FilePath { get; set; }
        public DateTime ReportDate { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
