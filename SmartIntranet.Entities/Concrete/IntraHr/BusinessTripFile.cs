using SmartIntranet.Core.Entities.Concrete;

namespace SmartIntranet.Entities.Concrete
{
    public class BusinessTripFile: BaseEntity
    {
        public string FilePath { get; set; }
        public int? ClauseId { get; set; }
        public Clause Clause { get; set; }
        public int? BusinessTripId { get; set; }
        public BusinessTrip BusinessTrip { get; set; }
    }
}
