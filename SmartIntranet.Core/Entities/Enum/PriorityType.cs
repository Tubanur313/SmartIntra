using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartIntranet.Core.Entities.Enum
{
    public enum PriorityType : byte
    {
        [Display(Name = "Normal")]
        Normal = 1,
        [Display(Name = "Təcili")]
        High ,
        [Display(Name = "Aşağı")]
        Low
    }
}
