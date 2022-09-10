using SmartIntranet.Core.Entities.Concrete;

namespace SmartIntranet.Entities.Concrete.IntraHr
{
    public class LongContractFile : BaseEntity
    {
        public string FilePath { get; set; }
        public int? ClauseId { get; set; }
        public Clause Clause { get; set; }
        public int? LongContractId { get; set; }
        public LongContract LongContract { get; set; }
    }
}
