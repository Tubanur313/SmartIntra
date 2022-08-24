using SmartIntranet.Core.Entities.Concrete;


namespace SmartIntranet.Entities.Concrete
{
    public class PersonalContractFile : BaseEntity
    {
        public string FilePath { get; set; }
        public int? ClauseId { get; set; }
        public Clause Clause { get; set; }
        public int? PersonalContractId { get; set; }
        public PersonalContract PersonalContract { get; set; }
    }
}
