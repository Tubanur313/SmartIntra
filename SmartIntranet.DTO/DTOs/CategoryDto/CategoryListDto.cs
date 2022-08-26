using SmartIntranet.Entities.Concrete.Intranet;
using System;

namespace SmartIntranet.DTO.DTOs.CategoryDto
{
    public class CategoryListDto
    {
        public int? Id { get; set; }
        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateByUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
