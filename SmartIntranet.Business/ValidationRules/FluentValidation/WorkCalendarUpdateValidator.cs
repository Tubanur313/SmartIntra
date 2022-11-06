using FluentValidation;
using SmartIntranet.DTO.DTOs.WorkCalendarDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class WorkCalendarUpdateValidator : AbstractValidator<WorkCalendarUpdateDto>
    {
        public WorkCalendarUpdateValidator()
        {
            RuleFor(I => I.Number).NotNull().WithMessage("İş saatı boş ola bilməz")
                //.LessThanOrEqualTo(24).WithMessage("İş saatı 0 dan kiçik 24 dən böyük ola bilməz")
                //.GreaterThanOrEqualTo(0);
                .InclusiveBetween(0, 24).WithMessage("İş saatı 0 dan kiçik 24 dən böyük ola bilməz");
        }
    }
}
