using FluentValidation;
using SmartIntranet.DTO.DTOs.AppRoleDto;


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
