using FluentValidation;
using SmartIntranet.DTO.DTOs.WorkCalendarDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class WorkCalendarAddValidator : AbstractValidator<WorkCalendarAddDto>
    {
        public WorkCalendarAddValidator()
        {
            RuleFor(I => I.Number).NotNull().WithMessage("İş saatı boş ola bilməz")
               .GreaterThan(-1).LessThan(25).WithMessage("İş saatı 0 dan kiçik 24 dən böyük ola bilməz");
                
        }
    }
}
