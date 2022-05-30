using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;


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
