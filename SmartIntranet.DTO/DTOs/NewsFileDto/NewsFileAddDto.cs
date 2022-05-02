using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.NewsFileDto
{
    public class NewsFileAddDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? NewsId { get; set; }
        public News News { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; } 
        public int? UpdateByUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
