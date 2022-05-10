using SmartIntranet.Core.Entities.Concrete;

namespace SmartIntranet.Entities.Concrete.Intranet
{
    public class CategoryNews : BaseEntity
    {
        public int NewsId { get; set; }
        public News News { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
