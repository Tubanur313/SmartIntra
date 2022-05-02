using FluentValidation;
using SmartIntranet.DTO.DTOs.CheckListDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class CheckListUpdateValidator : AbstractValidator<CheckListUpdateDto>
    {
        public CheckListUpdateValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
        }
    }
}
