using System.Collections.Generic;

namespace SmartIntranet.DTO.DTOs.CommonUseDto
{
    public class TreesDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<TreeDto> Children { get; set; }

    }
}
