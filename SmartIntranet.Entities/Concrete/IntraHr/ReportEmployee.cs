using System;
using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.Entities.Concrete.IntraHr
{
    public class ReportEmployee : BaseEntity
    {
        public string FilePath { get; set; }
        public string GeneratedReport { get; set; }
        public DateTime ReportDate { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
