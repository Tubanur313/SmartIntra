using FluentValidation;
using SmartIntranet.DTO.DTOs.AppUserDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class AppUserProfileValidator : AbstractValidator<AppUserProfileDto>
    {
        public AppUserProfileValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
            RuleFor(I => I.Surname).NotNull().WithMessage("Soyad boş ola bilməz");
            RuleFor(I => I.Email).NotNull().WithMessage("Email boş ola bilməz");
            RuleFor(I => I.Email).EmailAddress().WithMessage("Email doğru deyil");
            RuleFor(I => I.PhoneNumber).MinimumLength(10).WithMessage("Telefon nömrəsi 10 simvoldan kiçik olmamalıdır!")
            .MaximumLength(19).WithMessage("Telefon nömrəsi 19 simvoldan yüksək olmamalıdır!")
             .Matches(new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"))
             .WithMessage("Telefon nömrəsi uyğun deyil yalnız rəqəm daxil edin !");
        }
    }
}
