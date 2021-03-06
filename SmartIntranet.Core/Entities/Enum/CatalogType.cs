using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartIntranet.Core.Entities.Enum
{
    public enum CatalogType : byte
    {
        [Display(Name = "Yönləndirilən")]
        Directed= 1,
        [Display(Name = "Yönləndirilməyən")]
        Undirected ,
        [Display(Name = "Nəzarətçi olan")]
        Watched,
        [Display(Name = "Nəzarətçi olmayan")]
        NotWatched,
        [Display(Name = "Təsdiqlənmə sorğusu olan")]
        Confirms,
        [Display(Name = "Təsdiqlənmə sorğusu olmayan")]
        UnConfirms,   

    }
}
