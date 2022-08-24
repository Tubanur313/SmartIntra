﻿using SmartIntranet.Core.Entities.Concrete;
using System.Collections.Generic;


namespace SmartIntranet.Entities.Concrete
{
    public class ContractType : BaseEntity
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }

    }
}
