using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartIntranet.DTO.DTOs.ReportEmployeeDto
{
    public class ReportEmployeeDto
    {
        public int Id { get; set; }
        public IntranetUser User { get; set; }
        public string FilePath { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM yyyy}")]
        public DateTime ReportDate { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
