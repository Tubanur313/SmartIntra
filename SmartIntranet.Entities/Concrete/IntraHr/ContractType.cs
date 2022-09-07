using System.Collections.Generic;
using SmartIntranet.Core.Entities.Concrete;

namespace SmartIntranet.Entities.Concrete.IntraHr
{
    public class ContractType : BaseEntity
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }

    }
}
