using FluentValidation;
using SmartIntranet.DTO.DTOs.ClauseDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class ClauseAddValidator : AbstractValidator<ClauseAddDto>
    {
        public ClauseAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
        }
    }
}
