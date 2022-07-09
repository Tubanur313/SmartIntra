using FluentValidation;
using SmartIntranet.DTO.DTOs.TicketTripDtos.PermissionDtos;
using SmartIntranet.DTO.DTOs.TicketTripDtos.VacationLeaveDtos;

namespace SmartIntranet.Business.ValidationRules.FluentValidation.TicketTripValidate
{
    public class PermissionUpdateValidator : AbstractValidator<PermissionUpdateDto>
    {
        public PermissionUpdateValidator()
        {
            RuleFor(I => I.Reason).NotNull().WithMessage("İcazə Səbəbi boş ola bilməz");
            RuleFor(I => I.StartTime).NotNull().WithMessage("İcazə Başlama saatı boş ola bilməz");
            RuleFor(I => I.EndTime).NotNull().WithMessage("İcazə Bitmə saatı boş ola bilməz");
        }
    }
}
