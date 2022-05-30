using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartIntranet.Entities.Concrete
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
