using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.CategoryDto
{
    public class CategoryUpdateDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
