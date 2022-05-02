using FluentValidation;
using SmartIntranet.DTO.DTOs.GradeDto;


namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class GradeAddValidator : AbstractValidator<GradeAddDto>
    {
        public GradeAddValidator()
        {
            RuleFor(I => I.GradeName).NotNull().WithMessage("Ad boş ola bilməz");
        }
    }
}
