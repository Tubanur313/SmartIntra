using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartIntranet.Core.Entities.Enum
{
    public enum TicketChangeType : byte
    {
        [Display(Name = " Nömrəli Task Əlavə Olundu")]
        TicketAdd = 1,
        [Display(Name = " Nömrəli Taskda Dəyişiklik Olundu")]
        TicketUpdate,
        [Display(Name = " Nömrəli Taskın Statusu Dəyişdi")]
        TicketStatus,
        [Display(Name = " Nömrəli Taskın Kateqoriyası Dəyişdi")]
        TicketCategory,
        [Display(Name = " Nömrəli Taska Checklist Əlavə Olundu")]
        TicketChecklist,
        [Display(Name = " Nömrəli Taskın Prioriteti Dəyişdi")]
        TicketPriority,
        [Display(Name = " Nömrəli Taskda Müzakirəyə Əlavə Olundu")]
        TicketDiscuss,
        [Display(Name = " Nömrəli Taska Şəkil Əlavə Olundu")]
        TicketImage,
        [Display(Name = " Nömrəli Taska Nəzarətçi Olundu")]
        TicketWatcher, 
        [Display(Name = " Nömrəli Taska Təsdiqləyən Əlavə Olundu")]
        ConfirmUser,
        [Display(Name = " Nömrəli Taskda Təsdiq Olundu")]
        ConfirmUserAdd,
        [Display(Name = "Nömrəli Taska Təsdiq Sorgusu Əlavə Olundu")]
        ConfirmTicket,
        [Display(Name = "Nömrəli Task Yonlendirildi")]
        TicketSupportRedirect,
    }
}
