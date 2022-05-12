using FluentValidation;
using SmartIntranet.DTO.DTOs.AppUserDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class AppUserAddValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(I => I.FirstName).NotNull().WithMessage("Ad boş ola bilməz");
            RuleFor(I => I.LastName).NotNull().WithMessage("Soyad boş ola bilməz");
            RuleFor(I => I.Email).NotNull().WithMessage("Email boş ola bilməz");
            RuleFor(I => I.Email).EmailAddress().WithMessage("Email doğru deyil");
            RuleFor(I => I.CompanyId).NotNull().WithMessage("Şirkət boş ola bilməz");
            RuleFor(I => I.DepartmentId).NotNull().WithMessage("Şöbə boş ola bilməz");
            RuleFor(I => I.PositionId).NotNull().WithMessage("Vəzifə boş ola bilməz");
            RuleFor(I => I.Password).NotNull().WithMessage("Şifrə boş ola bilməz");
            RuleFor(I => I.PhoneNumber).MinimumLength(10).WithMessage("Telefon nömrəsi 10 simvoldan az olmamalıdır!")
            .MaximumLength(19).WithMessage("Telefon nömrəsi 18 simvoldan çox olmamalıdır!")
            .Matches(new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"))
            .WithMessage("Telefon nömrəsi uyğun deyil");
        }
    }
}
