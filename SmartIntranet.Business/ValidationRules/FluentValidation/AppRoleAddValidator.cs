using FluentValidation;
using SmartIntranet.DTO.DTOs.AppRoleDto;


namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class AppRoleAddValidator : AbstractValidator<AppRoleAddDto>
    {
        public AppRoleAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
        }
    }
}
