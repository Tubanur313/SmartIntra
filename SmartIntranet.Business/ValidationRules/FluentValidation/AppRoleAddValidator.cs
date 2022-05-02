using FluentValidation;
using SmartIntranet.DTO.DTOs.AppRoleDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class AppRoleAddValidator : AbstractValidator<AppRoleAddDto>
    {
        public AppRoleAddValidator()
        {
        }
    }
}
