using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.DepartmentDto
{
    public class DepartmentUpdateDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public Department Parent { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
