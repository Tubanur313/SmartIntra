using System.ComponentModel.DataAnnotations;

namespace SmartIntranet.Core.Entities.Enum
{
    public enum TicketType : byte
    {
        [Display(Name = "Tapşırıq")]
        Task = 1,
        [Display(Name = "Satınalma")]
        Purchasing,       
        [Display(Name = "Ezamiyyət")]
        BusinessTrip,
        [Display(Name = "İcazə")]
        Permit,
        [Display(Name = "Məzuniyyət")]
        Vacation
    }
}
