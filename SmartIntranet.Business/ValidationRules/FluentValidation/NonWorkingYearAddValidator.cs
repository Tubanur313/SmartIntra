using FluentValidation;
using SmartIntranet.DTO.DTOs.DepartmentDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class NonWorkingYearAddValidator : AbstractValidator<NonWorkingYearAddDto>
    {
        public NonWorkingYearAddValidator()
        {
            RuleFor(I => I.Year).NotNull().WithMessage("İl boş ola bilməz");
        }
    }
}
