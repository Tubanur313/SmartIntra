using SmartIntranet.Core.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.CommonUseDto
{
    public class TreeDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<TreeDto> Children { get; set; }
        public TicketType TicketType { get; set; }

    }
}
