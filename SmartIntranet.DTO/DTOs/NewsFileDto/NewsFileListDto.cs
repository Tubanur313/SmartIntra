using SmartIntranet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.NewsFileDto
{
    public class NewsFileListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? NewsId { get; set; }
        public News News { get; set; }

    }
}
