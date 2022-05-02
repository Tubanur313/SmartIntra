using SmartIntranet.Core.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartIntranet.Entities.Concrete
{
  
    public class Photo : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
