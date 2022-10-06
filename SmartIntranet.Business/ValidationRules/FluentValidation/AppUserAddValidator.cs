﻿using FluentValidation;
using SmartIntranet.DTO.DTOs.AppUserDto;
using System.Text.RegularExpressions;

namespace SmartIntranet.Business.ValidationRules.FluentValidation
{
    public class AppUserAddValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad boş ola bilməz");
            RuleFor(I => I.Surname).NotNull().WithMessage("Soyad boş ola bilməz");
            RuleFor(I => I.Email).NotNull().WithMessage("Email boş ola bilməz");
            RuleFor(I => I.Email).EmailAddress().WithMessage("Email doğru deyil");
            RuleFor(I => I.Salary).NotNull().WithMessage("Əmək haqqı boş ola bilməz");
            //RuleFor(I => I.IdCardExpireDate).NotNull().WithMessage("Vəsiqənin qüvvədə olma tarixi boş ola bilməz");
            RuleFor(I => I.StartWorkDate).NotNull().WithMessage("İşə başlama tarixi boş ola bilməz");
            RuleFor(I => I.CompanyId).NotNull().WithMessage("Şirkət boş ola bilməz");
            RuleFor(I => I.DepartmentId).NotNull().WithMessage("Şöbə boş ola bilməz");
            RuleFor(I => I.PositionId).NotNull().WithMessage("Vəzifə boş ola bilməz");
            RuleFor(I => I.Password).NotNull().WithMessage("Şifrə boş ola bilməz");
            RuleFor(I => I.VacationMainDay).NotNull().WithMessage("Məzuniyyət əsas günü sayı boş ola bilməz");
            RuleFor(I => I.IdCardNumber).NotNull().WithMessage("Vəsiqənin seriyası və nömrəsi boş ola bilməz");
            RuleFor(I => I.IdCardGiveDate).NotNull().WithMessage("Vəsiqənin verilmə tarixi boş ola bilməz");
            RuleFor(I => I.IdCardGivePlace).NotNull().WithMessage("Vəsiqəni verən orqanın adı boş ola bilməz");
            RuleFor(I => I.RegisterAdress).NotNull().WithMessage("Qeydiyyat ünvanı sayı boş ola bilməz");
            RuleFor(I => I.Gender).NotNull().WithMessage("Cins boş ola bilməz");
            RuleFor(I => I.WorkGraphicId).NotNull().WithMessage("İstehsalat təqvimi boş ola bilməz");

            RuleFor(I => I.PhoneNumber).MinimumLength(10).WithMessage("Telefon nömrəsi 10 simvoldan kiçik olmamalıdır!")
            .MaximumLength(19).WithMessage("Telefon nömrəsi 19 simvoldan yüksək olmamalıdır!")
            .Matches(new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"))
            .WithMessage("Telefon nömrəsi uyğun deyil yalnız rəqəm daxil edin !");
            RuleFor(I => I.PersonalPhoneNumber).MinimumLength(10).WithMessage("Telefon nömrəsi 10 simvoldan kiçik olmamalıdır!")
            .MaximumLength(19).WithMessage("Telefon nömrəsi 19 simvoldan yüksək olmamalıdır!")
            .Matches(new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"))
            .WithMessage("Telefon nömrəsi uyğun deyil yalnız rəqəm daxil edin !");
            RuleFor(I => I.HomePhoneNumber).MinimumLength(10).WithMessage("Telefon nömrəsi 10 simvoldan kiçik olmamalıdır!")
            .MaximumLength(19).WithMessage("Telefon nömrəsi 19 simvoldan yüksək olmamalıdır!")
            .Matches(new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"))
            .WithMessage("Telefon nömrəsi uyğun deyil yalnız rəqəm daxil edin !");
            RuleForEach(I => I.UserExperiences).SetValidator(new UserExperienceValidator());
        }
    }
}
