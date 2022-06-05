using FluentValidation;
using SmartIntranet.DTO.DTOs.AppUserDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class AppUserPassValidator : AbstractValidator<AppUserPassDto>
    {
        public AppUserPassValidator()
        {
            RuleFor(I => I.Password).NotNull().WithMessage("Şifrə boş ola bilməz");
            RuleFor(I => I.ConfirmPassword).NotNull().WithMessage("Təkrar Şifrə boş ola bilməz");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Təkrar Şifrə uyğun gəlmir!");
        }
    }
}
