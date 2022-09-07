using SmartIntranet.Core.Entities.Concrete;

namespace SmartIntranet.Entities.Concrete.IntraHr
{
    public class Place : BaseEntity
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        //public virtual ICollection<Contract> Contracts { get; set; }
    }
}
