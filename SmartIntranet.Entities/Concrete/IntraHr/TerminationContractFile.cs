using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;


namespace SmartIntranet.Entities.Concrete
{
    public class TerminationContractFile : BaseEntity
    {
        public string FilePath { get; set; }
        public int? ClauseId { get; set; }
        public Clause Clause { get; set; }
        public int? TerminationContractId { get; set; }
        public TerminationContract TerminationContract { get; set; }
    }
}
