using System.ComponentModel.DataAnnotations;

namespace SmartIntranet.Core.Entities.Enum
{
    public enum StatusType : byte
    {
        [Display(Name = "Açıq")]
        Open= 1,
        [Display(Name = "Bağlı")]
        Close,
        [Display(Name = "Gözləmədə")]
        Pause
    }
}
