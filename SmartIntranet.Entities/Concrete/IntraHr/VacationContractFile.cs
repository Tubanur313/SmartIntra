using SmartIntranet.Core.Entities.Concrete;


namespace SmartIntranet.Entities.Concrete
{
    public class VacationContractFile : BaseEntity
    {
        public string FilePath { get; set; }
        public int? ClauseId { get; set; }
        public Clause Clause { get; set; }
        public int? VacationContractId { get; set; }
        public VacationContract VacationContract { get; set; }
    }
}
