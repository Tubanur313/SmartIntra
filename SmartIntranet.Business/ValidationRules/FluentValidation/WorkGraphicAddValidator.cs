using FluentValidation;
using SmartIntranet.DTO.DTOs.WorkGraphicDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class WorkGraphicAddValidator : AbstractValidator<WorkGraphicAddDto>
    {
        public WorkGraphicAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
            RuleFor(I => I.NonWorkingYearId).NotNull().WithMessage("İl boş ola bilməz");
        }
    }
}
