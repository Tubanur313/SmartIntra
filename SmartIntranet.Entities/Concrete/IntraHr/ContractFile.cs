using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;


namespace SmartIntranet.Entities.Concrete
{
    public class ContractFile : BaseEntity
    {
        public string FilePath { get; set; }
        public bool IsClause { get; set; }
        public int? ClauseId { get; set; }
        public Clause Clause { get; set; }
        public int? ContractId { get; set; }
        public Contract Contract { get; set; }
    }
}
