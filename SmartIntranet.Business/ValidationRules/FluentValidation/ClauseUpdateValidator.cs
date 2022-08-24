using FluentValidation;
using SmartIntranet.DTO.DTOs.ClauseDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class ClauseUpdateValidator : AbstractValidator<ClauseUpdateDto>
    {
        public ClauseUpdateValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
        }
    }
}
