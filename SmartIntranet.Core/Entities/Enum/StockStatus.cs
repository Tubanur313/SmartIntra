﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartIntranet.Core.Entities.Enum
{
    public enum StockStatus : byte
    {
        [Display(Name = "Təyin olunan")]
        Assigned = 1,
        [Display(Name = "Təyin olunmayan")]
        NonAssigned
    }
}
