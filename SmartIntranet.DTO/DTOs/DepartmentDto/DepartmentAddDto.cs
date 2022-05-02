using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.DepartmentDto
{
    public class DepartmentAddDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public Department Parent { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateByUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
