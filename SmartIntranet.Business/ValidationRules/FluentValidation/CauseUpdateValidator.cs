using FluentValidation;
using SmartIntranet.DTO.DTOs.CauseDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class CauseUpdateValidator : AbstractValidator<CauseUpdateDto>
    {
        public CauseUpdateValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
        }
    }
}
