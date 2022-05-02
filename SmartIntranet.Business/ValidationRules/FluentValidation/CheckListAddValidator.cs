using FluentValidation;
using SmartIntranet.DTO.DTOs.CheckListDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class CheckListAddValidator : AbstractValidator<CheckListAddDto>
    {
        public CheckListAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
        }
    }
}
