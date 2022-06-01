using SmartIntranet.Core.Entities.Concrete;

namespace SmartIntranet.Entities.Concrete.Inventary
{
    public class StockImage:BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int? StockId { get; set; }
        public Stock Stock { get; set; }
    }
}
