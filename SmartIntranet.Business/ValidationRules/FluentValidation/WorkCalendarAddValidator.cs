using FluentValidation;
using SmartIntranet.DTO.DTOs.WorkCalendarDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class WorkCalendarAddValidator : AbstractValidator<WorkCalendarAddDto>
    {
        public WorkCalendarAddValidator()
        {
            RuleFor(I => I.Number).NotNull().WithMessage("İş saatı boş ola bilməz");
        }
    }
}
