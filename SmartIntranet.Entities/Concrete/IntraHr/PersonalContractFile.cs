using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;


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
