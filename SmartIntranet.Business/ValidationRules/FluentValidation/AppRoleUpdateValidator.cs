using FluentValidation;
using SmartIntranet.DTO.DTOs.AppRoleDto;
using SmartIntranet.DTO.DTOs.GradeDto;


namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class AppRoleUpdateValidator : AbstractValidator<AppRoleUpdateDto>
    {
        public AppRoleUpdateValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
        }
    }
}
