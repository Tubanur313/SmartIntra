using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.ReportEmployeeDto
{
    public class ReportEmployeeDto
    {
        public int Id { get; set; }
        public IntranetUser User { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateByUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }

        public string FilePath { get; set; }
        public DateTime ReportDate { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
