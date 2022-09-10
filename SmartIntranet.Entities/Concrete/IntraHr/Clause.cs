using System.Collections.Generic;
using SmartIntranet.Core.Entities.Concrete;

namespace SmartIntranet.Entities.Concrete.IntraHr
{
    public class Clause : BaseEntity
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public bool IsDeletable { get; set; } // seed de yaranma statusu
        public bool IsBackground { get; set; } // arxa planda isledilir
        public string FilePath { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
