using FluentValidation;
using SmartIntranet.DTO.DTOs.TicketTripDtos.VacationLeaveDtos;

namespace SmartIntranet.Business.ValidationRules.FluentValidation.TicketTripValidate
{
    public class VacationLeaveAddValidator : AbstractValidator<VacationLeaveAddDto>
    {
        public VacationLeaveAddValidator()
        {
            RuleFor(I => I.VacationKind).NotNull().WithMessage("Məzuniyyət Növü boş ola bilməz");
            RuleFor(I => I.StartDate).NotNull().WithMessage("Məzuniyyət Başlama Tarixi boş ola bilməz");
            RuleFor(I => I.EndDate).NotNull().WithMessage("Məzuniyyət Bitmə Tarixi boş ola bilməz");
        }
    }
}
