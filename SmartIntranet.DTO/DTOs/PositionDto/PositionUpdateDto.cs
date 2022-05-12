using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.PositionDto
{
    public class PositionUpdateDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public Position Parent { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
