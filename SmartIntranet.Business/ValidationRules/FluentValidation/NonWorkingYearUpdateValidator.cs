using FluentValidation;
using SmartIntranet.DTO.DTOs.DepartmentDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class NonWorkingYearUpdateValidator : AbstractValidator<NonWorkingYearUpdateDto>
    {
        public NonWorkingYearUpdateValidator()
        {
            RuleFor(I => I.Year).NotNull().WithMessage("İl boş ola bilməz");
        }
    }
}
