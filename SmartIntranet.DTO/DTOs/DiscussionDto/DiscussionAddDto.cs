using Microsoft.AspNetCore.Http;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System.Collections.Generic;

namespace SmartIntranet.DTO.DTOs.DiscussionDto
{
    public class DiscussionAddDto
    {
        public string Content { get; set; }
        public int? TicketId { get; set; }
        //public List<IFormFile> Uploads { get; set; }
        //public string Uploads { get; set; }
    }
}
