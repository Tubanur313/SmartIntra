using System.ComponentModel.DataAnnotations;

namespace SmartIntranet.Core.Entities.Enum
{
    public enum VacationKind : byte
    {
        [Display(Name = "Əmək məzuniyyəti")]
        PaidVacation = 1,
        [Display(Name = "Ödənişsiz məzuniyyət")]
        UnPaidVacation,       
        [Display(Name = "Təhsil məzuniyyəti")]
        EducationalLeave,
        [Display(Name = "Hamiləliyə və doğuma görə məzuniyyət")]
        PregnancyLeave,
        [Display(Name = "Uşağa qulluqla əlaqədar sosial məzuniyyət")]
        ChildCareVacation
    }
}

