﻿using SmartIntranet.Entities.Concrete.Intranet;
using System;

namespace SmartIntranet.DTO.DTOs.DepartmentDto
{
    public class DepartmentListDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public Department Parent { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateByUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
