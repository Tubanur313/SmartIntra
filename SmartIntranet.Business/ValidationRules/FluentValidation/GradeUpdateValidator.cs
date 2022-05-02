using FluentValidation;
using SmartIntranet.DTO.DTOs.GradeDto;


namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class GradeUpdateValidator : AbstractValidator<GradeUpdateDto>
    {
        public GradeUpdateValidator()
        {
            RuleFor(I => I.GradeName).NotNull().WithMessage("Ad boş ola bilməz");
        }
    }
}
