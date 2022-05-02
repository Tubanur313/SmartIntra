using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.CategoryNewsDto
{
    public class CategoryNewsListDto
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
