using FluentValidation;
using SmartIntranet.DTO.DTOs.AppRoleDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class AppRoleUpdateValidator : AbstractValidator<AppRoleUpdateDto>
    {
        public AppRoleUpdateValidator()
        {
        }
    }
}
