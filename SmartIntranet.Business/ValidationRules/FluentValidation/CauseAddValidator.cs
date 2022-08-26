using FluentValidation;
using SmartIntranet.DTO.DTOs.CauseDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class CauseAddValidator : AbstractValidator<CauseAddDto>
    {
        public CauseAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
        }
    }
}
