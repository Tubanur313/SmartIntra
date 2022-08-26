using FluentValidation;
using SmartIntranet.DTO.DTOs.AppUserDto;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator : AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            
            RuleFor(I => I.Email).NotNull().WithMessage("Email boş ola bilməz");
            RuleFor(I => I.Password).NotNull().WithMessage("Şifrə boş ola bilməz");
        }
    }
}
