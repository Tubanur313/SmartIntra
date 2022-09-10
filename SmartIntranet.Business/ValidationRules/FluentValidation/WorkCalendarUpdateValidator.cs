using FluentValidation;
using SmartIntranet.DTO.DTOs.WorkCalendarDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class WorkCalendarUpdateValidator : AbstractValidator<WorkCalendarUpdateDto>
    {
        public WorkCalendarUpdateValidator()
        {
            RuleFor(I => I.Number).NotNull().WithMessage("İş saatı boş ola bilməz");
        }
    }
}
