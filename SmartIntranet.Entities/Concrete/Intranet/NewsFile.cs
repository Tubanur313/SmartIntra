using SmartIntranet.Core.Entities.Concrete;

namespace SmartIntranet.Entities.Concrete.Intranet
{
    public class NewsFile : BaseEntity
    {
        public string Name { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
    }
}
